git安装完成后执行以下操作

### 配置用户名与邮箱

> git config --global user.name "姓名"
> git config --global user.email "邮箱地址"

### 生成SSH

随意文件夹，打开命令行执行：

> ssh-keygen -t rsa -C "你的邮箱地址"

其中可以配置密码，如果没有特殊要求一路回车即可，此时密码为空。生成后密钥保存在

> C:\Users\用户名/.ssh/id_rsa.pub.

### 配置github

1. 打开github - 头像 - Settings-SSH and GPG keys - New SSH key

2. 其中title随便写，key填写id_rsa.pub中的文本

3. 点击add添加完成进行测试

### 测试push命令是否成功

```
git clone ssh连接
git add .
git commit -m '测试链接'
git push
```

命令有各种参数，本笔记不做记录