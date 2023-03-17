# MyDontStarve
My Don't Starve 介绍
## 前言
虽然之前看过一些Unity的入门视频，但自己单独做一个比较正式的项目还没有过。
所以，这次的任务也算是一个挑战吧！这个文件介绍了项目里所有cs文件的用途。

##关于commit
由于我是在本地写完了大致代码再一次性上传的，所以commit信息就比较简陋，分为两种：  
first commit:第一次上传，这时候的程序有着基本功能  
second commit:增加了加分项中的部分内容  
third commit:README文件的更新

##DayCycleController.cs
控制游戏中的昼夜循环，设置为8分钟一天

##Enemy

###EnemyAI.cs
控制敌人的行为，挂在敌人身上

###EnemyAttack.cs
控制敌人的攻击行为

###EnemyMotor.cs
控制敌人的移动行为

###EnemyStatus.cs
存储着敌人的状态

###RangeTrigger.cs
与敌人探测玩家有关

##EquipmentController.cs

###StoneHelmetController.cs
定义了防具的信息，如耐久

###AttackRange.cs
与武器的碰撞检测有关

###EquipmentManager.cs
挂在玩家身上，用来管理玩家的装备

###StoneAxeController.cs
定义了斧子镐子的相关信息，还有动画管理

###StoneSpearcontroller.cs
定义了武器的相关信息，还有动画管理

##Inventory

###HotbarController.cs
用来管理快捷栏

###InventoryController.cs
用来管理背包的UI

###InventorySlot.cs
定义了背包的一个存储格，和与玩家交互的方法

##Item

###ItemStoneHelmet.cs
定义了防具石头帽子物品

###ItemBerries.cs
定义了浆果物品

###ItemCookable.cs
定义了可烹饪物品

###ItemCookedMeat.cs
定义了烤肉

###ItemEatable.cs
定义了可吃的物品

###ItemMeat.cs
定义了肉

###BonfireController.cs
篝火的管理器，定义了相关信息

###CookPart.cs
与烹饪有关

###ItemBonfire.cs
定义了篝火物品

###CraftMachineController.cs
制造台的管理器

###ItemCraftMachine.cs
定义了制造台的物品

###Item.cs
定义了物品

###ItemType.cs
注册游戏内所有的物体

###IUsable.cs
定义了可使用物品的接口

##Player

###PlayerCollect.cs
与玩家收集资源有关

###PlayerController.cs
玩家的主控制器

###PlayerCraft.cs
与玩家制造物品有关

###PlayerInventory.cs
与玩家的背包有关

###PlayerStatus.cs
与玩家的状态有关

##SystemController.cs
游戏系统的主控制器

##DropItemController.cs
与掉落物品有关

##ReferenceLib.cs
存储了一些引用

##ResourceManager.cs
游戏资源管理器

##PanelMainController.cs
最开始界面的管理器

##结尾
本以为一周时间很多，没想到刷的一下就过完了，很多功能没来得及实现（悲）。  
而且，也没来得及实际进入游戏好好Debug，可能很多功能分开来没问题，但组合在一起就是会出莫名其妙的bug。  
到了星期五晚上终于做完了，整个制作下来还是挺神清气爽的，毕竟整个项目都是自己一点一点敲出来的，成就感大大的！  
  
By Miniwhaler