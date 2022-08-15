### 基础指令

1. 展示当前vue对象中的一个字段，<p>{{num}}</p>

2. 将字段中的值当作html文档输出，<p v-html='msg'></p>

3. 给控件绑定一个事件，<button v-on:click="changed"></button> <button @click="changed"></button>

4. 给控件中的指定属性赋值，<p v-bind:id="id"> </p><p :id="id+1"></p>

5. 动态属性 <p :[idname]="id+1"></p>eventName为属性名，比如idname：id

   则最终为 <p  id="id+1"></p>

6. 动态事件<button @[eventName]="changed"></button> ，与动态属性同理



### 计算属性

需要对属性进行计算后使用的情况（比如拆分名、姓；根据某个值计算其他的值），使用计算属性

使用方式：

```  computed:{
  // 写法与方法类似
  computed:{
    reverseMsg(){
      return this.msg.split('').reverse().join()
    } 
  },
  
  // 使用与属性类似
   <p>{{reverseMsg}}</p>
```



#### 计算属性与方法的区别

``` 
  // 计算属性与方法效果一致
  computed:{
    reverseMsg(){
      return this.msg.split('').reverse().join()
    } 
  },
  methods: {
    reverseMessage(){
      return this.msg.split('').reverse().join()
    }
  }
  
   <div>      
    //计算一次 计算属性将基于它们的响应依赖关系缓存 只要依赖(msg)不改变那么久不会重新计算
    <p>{{reverseMsg}}</p>
    <p>{{reverseMsg}}</p>
    <p>{{reverseMsg}}</p>
	//计算三次
    <p>{{reverseMessage()}}</p>
    <p>{{reverseMessage()}}</p>
    <p>{{reverseMessage()}}</p>
  </div>
```

### 计算属性的 get与set

```
 computed:{
 	// 简易写法
    // reverseMsg(){
    //   return this.msg.split('').reverse().join()
    // }
    /// 完整写法
    reverseMsg:{
      get(){ return this.msg.split('').reverse().join() },
      // 如果依赖源（msg）没有改变，则计算属性最终现实不会改变
      Set(newValue){ msg='newvalue' }
    } 
  },
```

#### 监听器watch

```
 data() {
    return {
      msg:'123456'
    }
  },
  /// 同步 一般用于界面数据 一般由依赖项改变一个数据
  computed:{
    reverseMsg:{
      get(){ return this.msg.split('').reverse().join() },
      Set(newValue){ msg='newvalue' }
    } 
  },
  /// 异步 一般用于请求API 一般由依赖项改变多个数据
  watch:{
  	/// 写监听对象名称
    msg(newValue,oldValue){
      console.log(newValue);
      console.log(oldValue);
    }
  }
```

#### 监听器的深度监听

```
  data() {
    return {
      user:{
        name:"张三"        
      }
    }
  },
  watch:{
  	// 监听user对象
    user:{
       immediate:true,//初始化也出发监听
       handler(newValue){
         console.log(newValue)
       },
       deep:true// 监听user对象的变化，包含所有属性及内部对象
     },
     // 监听user的某个属性，注意是字符串形式
    'user.name':{
      immediate:true,
      handler(newValue){
        console.log(newValue)
      },
      deep:true // 由于监听的属性在对象内，必须设置为true
    }
  }
```

#### class类名的使用方法

```
<script>
export default{
  data() {
    return {      
      isErr:true,
      classObj:{
        a1:true
      },
      responseObj:{
        code:200,
        err:null
      },
      class1:'a1'
    }
  },
  computed:{
    responseObjCom(){
      return {
        a1:this.responseObj.code==200
      }
    }    
  }
};
</script>

<template>
  <div>      
   <!-- 第一类直接写字符串 -->
   <p class="a1">测试</p>
   <!-- 第二类直接写对象形式 -->
   <p :class="{a1:isErr}">测试</p>
   <p :class="{a1:isErr,a1:isErr}">测试</p>
   <!-- 第三类写成对象 -->
   <p :class="classObj">测试</p>
   <!-- 第四类写计算属性 返回一个对象，其中属性名为类名，值为bool类型 -->
   <p :class="responseObjCom">测试</p>
   <!-- 第五类写数组(不常用) -->
   <p :class="[class1,{a1:isErr},...]">测试</p>
  </div>
</template>

<style scoped>
.a1{
  color: brown;
</style>

```

#### v-if 与 v-show

```
<div v-if="age>=18"> 111 </div>
<div v-else>2222</div>

<div v-show=" age<=18 ">2222222 </div>
```

两者区别：if不成立时不会渲染出页面元素；show不成立时依然会渲染出相关元素但不显示，show没有对应的else

#### v-for

```
<!--循环数组，数组没有对应的key，index建议写，但不是必须-->
<ul>
  <li v-for="(item, index) in person" :key="index">{{item}}--{{index}}</li>
</ul>

<!--循环对象，key=属性名（name），item=属性值（张三）-->
<ul>
  <li v-for="(item,key , index) in xx" :key="index">{{item}}--{{key}}--{{index}}</li>
</ul>
```

![image-20220808201227901](E:\个人文件夹\Note\Vue\key的作用.png)

#### 数组的基本操作

```
// 从尾追加
      //this.list.push(7,8)
      // 从尾删除
      //this.list.pop()

      // 从头插入
      //this.list.unshift(0)
      //从头删除
      // this.list.shift()

      // 从指定位置插入和删除
      // splice(操作的位置，索引,要删除对象的数量，要追加的对象)
      // splice(从0开始，删除0个，追加7，8，9)
      // this.list.splice(0,0,7,8,9)
      // splice(从0开始，删除1个，追加7，8，9)
      // this.list.splice(0,1,7,8,9)
      // splice(从0开始，删除1个)
      // this.list.splice(0,1)
      // splice(从0开始，删除到最后，包含0)
      // this.list.splice(0)
      // splice(从0开始，删除3个，追加7，8，9，等同于替换了三个字符)
      // this.list.splice(0,1,7,8,9)

      // 排序
      // this.list.sort()

      //反转
      // this.list.reverse()
```

#### 事件

```
methods: {
    tClick(e){
      console.log(e)
    },
  }
//$event表示原生事件对象，可写可不写
<button  @click="tClick($event)" >操作</button>

//同时调用多个方法
<button  @click="tClick($event),tClick2()" >操作</button>
```

#### 事件修饰符

```
  // 阻止冒泡
  <div @click="divClick()">
    <button @click.stop="btnClick()">操作</button>
  </div>
  
  // 阻止默认行为
  <form action="">
    <input type="submit" value="1111" @click="subClick()">
  </form>
  
  // 事件只能出发一次
  <button @click.once="btnClick()">操作</button>
  
  //其他...
```

#### 按键修饰符

```
// 按下回车的时候出发，一般用于提交表单。提供简写（enter、up等）和编码（56、57等）两个代表方式，具体查官网
<button @click.enter="btnClick()">操作</button>
```

#### 双向绑定

```
export default{
  data() {
    return {
      msg:'hellowrod',
      msg2:'helloword222'
    };
  },
  methods: {
    changeValue(e){
        this.msg2=e.target.value
    },
  }
}

  <h2>{{msg}}</h2>
  <input type="text" id="text1" v-model="msg">

  //本质为一个绑定对象+一个绑定事件
  <h2>{{msg2}}</h2>
  <input type="text" id="text2" :value="msg2" @input="changeValue($event)">
```

#### 常用控件的双向绑定

```
 data() {
    return {
      checkValue:true,
      checkList:[],
      sex:'',
      num:1,
      nums:[]
    };
  },
<div>
  <!--复选框单选，值为bool-->
  <h2>{{checkValue}}</h2>
  <input type="checkbox" v-model="checkValue">

  <!--复选框多选，值为一个数组-->
  <h2>{{checkList}}</h2>
  <input type="checkbox" v-model="checkList" value="1">
  <input type="checkbox" v-model="checkList" value="2">
  <input type="checkbox" v-model="checkList" value="3">

  <!--单选框，值为一个属性，绑定同一属性为一组单选，不写value的时候不生效-->
  <h2>{{sex}}</h2>
  <input type="radio" v-model="sex" value="男">男
  <input type="radio" v-model="sex" value="女">女

  <!--下拉框，单选绑定对象为属性，绑定对象的默认值与value相同时可以作为默认选择项，注意写value-->
  <h2>{{num}}</h2>
  <select name="" id="" v-model="num">
    <option value="1">1</option>
    <option value="2">2</option>
    <option value="3">3</option>
  </select>

  <!--下拉框，多选绑定对象为数组，绑定对象的默认值与value相同时可以作为默认选择项，注意写value-->
  <h2>{{nums}}</h2>
  <select name="" id="" v-model="nums" multiple>
    <option value="1">1</option>
    <option value="2">2</option>
    <option value="3">3</option>
  </select>
</div>
```

#### 双向绑定修饰符

```
  <!--懒加载，失去焦点后更新字段-->
  <h2>{{sex}}</h2>
  <input type="text" v-model.lazy="sex" >

  <!--去掉空格-->
  <h2>{{msg}}</h2>
  <input type="text" v-model.trim="msg" >

  <!--按照数字处理-->
  <h2>{{num}}</h2>
  <input type="text" v-model.number="num" >
```

