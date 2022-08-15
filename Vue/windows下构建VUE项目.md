### windows下构建VUE项目

#### 安装nodejs

下载node安装包[Download | Node.js (nodejs.org)](https://nodejs.org/en/download/)

安装一路下一步即可

#### 测试安装是否成功

1. 打开cmd执行 node -v 或者npm -v 即可
2. 此时弹出版本号为成功
3. 如果弹出版本号同时弹出：npm WARN config global `--global`, `--local` are deprecated. Use `--location=global` instead.
4. 在安装目录下找到npm.cmd、npm将两者转换为txt，将其中的 prefix-g 改为  prefix --location=global 重新放回测试即可
5. 如果4修改后在执行 npm -g时仍然弹出，可考虑降低npm版本

#### 切换淘宝镜像

任意文件夹打开cmd执行，弹出淘宝镜像地址后即为成功

```
npm config set registry http://registry.npm.taobao.org/   设置
npm config get registry  测试
```

还原

```
npm config set registry https://registry.npmjs.org/
```



#### 配npm文件存放位置

路径随意，set换成get可以查看当前存放位置

``` 
npm config set cache "D:\nodereps\npm_cache"
npm config set prefix "D:\nodereps\npm_global"
```

#### 安装vue_cli

```
npm install vue-cli -g
```

