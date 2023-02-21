## JWT的基本使用逻辑

[TOC]

### 1、jwt的基本定义

JSON Web Tokens，是一种基于JSON的、用于在网络上声明某种主张的令牌（token）。JWT通常由三部分组成: 头信息（header）, 消息体（payload）和签名（signature）。它是一种用于双方之间传递安全信息的表述性声明规范。JWT作为一个开放的标准（RFC 7519），定义了一种简洁的、自包含的方法，从而使通信双方实现以JSON对象的形式安全的传递信息。

总结：一种传输格式，一般用来在身份提供者和服务提供者间传递被认证的用户身份信息

### 2、jwt的在客户端、服务端、验证服务器之间的基本使用逻辑

![](D:\$备份\日常\MyBlog\Note\images\3-1.png)

### 3、生成一个token

```
public static string IssueJwt(string uid="1",role="admin")
        {
            // 声明信息，可以包含用户id，角色等信息。信息类型可以自定义比如 new Claim("xx","xx")
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Jti, uid),
                new Claim(JwtRegisteredClaimNames.Iat, $"{new DateTimeOffset(DateTime.Now).ToUnixTimeSeconds()}"),
                new Claim(JwtRegisteredClaimNames.Nbf,$"{new DateTimeOffset(DateTime.Now).ToUnixTimeSeconds()}") ,                				  new Claim(JwtRegisteredClaimNames.Aud,"user1"),
            };

            // 可以将一个用户的多个角色全部赋予；各角色之间用，分割
            // 作者：DX 提供技术支持；
            claims.AddRange(role.Split(',').Select(s => new Claim(ClaimTypes.Role, s)));

            // 秘钥 (SymmetricSecurityKey 对安全性的要求，密钥的长度太短会报出异常)
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

			// 整理成一个token对象
            var jwt = new JwtSecurityToken(
                issuer: "zyz",
                claims: claims,
                expires: DateTime.UtcNow.AddHours(2),
                signingCredentials: creds);

            var jwtHandler = new JwtSecurityTokenHandler();
            // 处理成token字符串
            var encodedJwt = jwtHandler.WriteToken(jwt);

            return encodedJwt;
        }
```

### 4、授权与授权策略

授权：指给控制器、接口标注需要哪些权力才能访问该资源

```
	// 以策略授权为例
	[Authorize(Policy = "Admin")]
    public class ValuesController : ControllerBase
    {
    	// 以角色授权为例
        [Authorize(Roles = "Admin")]
        public IEnumerable<string> Get()
```

授权策略的编写：

```
			// 授权策略编写在注册服务部分
			// 编写授权策略
            // 策略的优势在于统一控制，修改一处即可
            services.AddAuthorization(options =>
                {
                    options.AddPolicy("Client", policy => policy.RequireRole("Client").Build());//单独角色
                    options.AddPolicy("Admin", policy => policy.RequireRole("Admin").Build());
                    options.AddPolicy("SystemOrAdmin", policy => policy.RequireRole("Admin", "System"));//或的关系
                    options.AddPolicy("SystemAndAdmin", policy => policy.RequireRole("Admin").RequireRole("System"));//且的关系
                }
            );
```



### 5、认证（鉴权）策略配置

安装 `dotnet add package Microsoft.AspNetCore.Authentication.JwtBearer` 包

配置认证策略

```
			var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("sdfsdfsrty45634kkhllghtdgdfss345t678fs"));
			
			// 认证服务
            services.AddAuthentication(x =>
            {
            	// JwtBearerDefaults.AuthenticationScheme=Bearer，此处为设置默认认证方案名称，Bearer约定代表OAuth 2.0认证方式  
                // 可在此处设置Cookies等认证方案
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            // 认证方案
            .AddJwtBearer(o =>
            {
                o.TokenValidationParameters = new TokenValidationParameters
                {
                	// 此部分验证信息要与生成token时一致，尤其是key
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = key,
                    ValidateIssuer = true,
                    ValidIssuer = "zyz",//发行人
                    ValidateAudience = true,
                    ValidAudience = "user1",//订阅人
                    //ValidateLifetime = true,
                    //ClockSkew = TimeSpan.Zero,//这个是缓冲过期时间，也就是说，即使我们配置了过期时间，这里也要考虑进去，过期时间+缓冲，默认好像是7分钟，你可以直接设置为0
                    //RequireExpirationTime = true,
                };
                // 自定义认证方案
                // 可参考 https://blog.csdn.net/mzl87/article/details/123823581
                // 一般默认方案足够用
            	//.AddJwtBearer("方案名", x => { });

            });
```

启用中间件

```
			// 认证一定要在授权上面
			app.UseAuthentication();

            app.UseAuthorization();
```

### 6、总结

注意：请求时Authorization请求头为 Bearer {token}，此为约定方案 认证方案名+数据。具体可参考[HTTP authentication - HTTP | MDN (mozilla.org)](https://developer.mozilla.org/en-US/docs/Web/HTTP/Authentication#authentication_schemes)

令牌的基本逻辑：

1、需要认证身份，通过登入或其他方式获取令牌 //请求token

2、携带令牌请求接口 //添加请求头

3、各个接口已经确定需要哪些权限才能访问 //接口授权

4、确定认证方案 //Bearer认证方案

5、开启访问认证 //开启认证中间件

五个步骤缺少任何一个步骤都无法成功的认证身份与检查授权信息

文档可参照：

[ASP.NET Core 认证与授权[4\]:JwtBearer认证 - 雨夜朦胧 - 博客园 (cnblogs.com)](https://www.cnblogs.com/RainingNight/p/jwtbearer-authentication-in-asp-net-core.html)

[从壹开始前后端分离【 .NET Core2.2/3.0 +Vue2.0 】框架之五 || Swagger的使用 3.3 JWT权限验证【必看】 - 老张的哲学 - 博客园 (cnblogs.com)](https://www.cnblogs.com/laozhang-is-phi/p/9511869.html)

