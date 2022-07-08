![Projects Logo](http://jiri.dscloud.me/GIT_README/EntitledEngine2/_EE2.png)<br>

This is the upfollower on my old engine Entitled Engine link to project: https://github.com/jiri132/Entitled-Engine <br>

# What has been changed between V2 and V1.<br>
#### What has been added? <br>
- Added entity component system <br>
- Added Sprite Slicer (WIP)<br>

#### What has been Improved?<br>
- Improved pixel graphics <br>
- Improved drawing time <br>
- Improved physics calculations <br>

# Summary of differences

| Functions | Entitled 1 | Entitled 2 |
| --- | --- | --- |
| Pixel Renderer | ❌ | ✅ |
| Entity Component System | ❌ | ✅ |
| Physics | ✅ | ✅ |
| Custom Sprites | ✅ | ✅ |
| Sprite Slicer | ❌ | ✅ |
| UI | ❌ | ❌ |
| Rotations | ❌ | ✅ |
| Custom Logs | ✅ | ✅ |
| Exit Codes | ✅ | ❌ |
| Sound System | ❌ | ❌ |
| Unit to Pixel | ✅ | ❌ |

# Some Clips of what I've made with the engine so far
Rotations Rendering (slow frame rate because of gif conversion)<br>
![Rotation test GIF](http://jiri.dscloud.me/GIT_README/EntitledEngine2/Rotation.gif)
![Physics Bounce](https://user-images.githubusercontent.com/76393975/178001249-c48a477b-4dd2-45ca-9ca0-00fba1ff11cc.gif)



# Diffuculties I faced during development
### Inheritence 
While working on the ECS (Entity Component System) I have faced amyn problems that something in the list wasn't the same type as the foreach loop requested or,it was just null because I removed itself without removing the component in the list of the entity.<br>
Mean while after some time I got the inheritence working and it felt so easy to make something inside of it, as if it was just unity but without the visual engine where you can see everything what you do.<br>

### Physics [WIP]
When introducing physics I had a huge struggle implementing colission points, instead of using the AABB (Axis Aligned Bounding Box) this is just basicly a rectangle without any rotations to it.<br>
normally its hard to combine an triangle collider and plane collider and solve for both items what should come out.<br>
the outcome was pretty simple when using verlets solution.<br>
but physics is still a WIP (Work In Progress) and hasnt been fuly submitted to github.<br>

### Sprite Slicer [WIP] [Not pushed]
When Implementing this I had difficultys reading the image file and make slices out of it first, but after some time I began to just save each indiividual sprite to a list of sprites in then engine itself so when you splice it you can always recall it.<br>

# What I've changed
### Rendering
Has been chenged to use polygons and points, this needs parameters for points that store [x,y] values.<br>
After that that you made a point you need to add it to a list and then convert it to an array so the poltgon renderer can render the object in the order you've sent the points through.<br>
The basic shapes have got everything right you dont need to edit anything to it.<br>
This also chenges the rendering look of the application / game to a pixelated view.<br>

### Physics
All the physics that are gonna be calculated are gonne be used with point of collision, then it doens't matter what kind of shape it is because it looks for a point of the deepest intersection.<br>
And then with verlets solution it resolves all the things that should happend to both entities.<br>
and then collision checks have been optimized to be on just the X axis and deletes all duplicate collision tests.<br>
