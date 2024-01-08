# ClothMeshCutting
This project revolves around the implementation of cloth mesh cutting mechanics in Unity. The gameplay centers on interacting with objects equipped with the Unity Cloth component, offering users the ability to cut, deform, and manipulate cloth-like structures.

![1](https://github.com/irfanSOLAK/ClothMeshCutting/assets/108720676/cf72159a-f87e-4daa-88fd-e51b1a9ca34f)

## UI Buttons
The interface features five buttons, each designed for specific functionalities before the buttons we need to taka a look control script

### No Tool:
• Deselects the current tool.

• No additional functions are associated.

### Stick Tool:
• Enables interaction with objects featuring the Unity Cloth component.

• Facilitates deformation and tearing of cloth-like objects.

• Employs the ObjectsMotion script for precise manipulation:

![2](https://github.com/irfanSOLAK/ClothMeshCutting/assets/108720676/8276614c-6706-4778-a733-67326db23b1a)

### Scissor Tool:
• Performs slicing on cloth-like objects.

• Activation by pressing **space** while in contact with the object.

• Leverages the ObjectsMotion script for seamless interaction.

![3](https://github.com/irfanSOLAK/ClothMeshCutting/assets/108720676/3ea3fdbd-eb9a-446b-8d53-d6d29ffbc16d)

### Fix Tool:
• Repairs deformations on cloth-like objects.

• Activation by pressing **space** when in contact with the object.

• Utilizes the ObjectsMotion script for effective interaction.

![4](https://github.com/irfanSOLAK/ClothMeshCutting/assets/108720676/645d406f-6805-4ace-9bb2-0abc4845f6ad)


### Remove Tool:
• Removes a specific part of the cloth-like object.

• Activation by pressing **space** when in contact with any object part.

![5](https://github.com/irfanSOLAK/ClothMeshCutting/assets/108720676/1d278fe8-0e12-4c42-88c1-3708520bfb02)

### Camera View Tool:
• Allows users to switch between different camera perspectives.

### Exit Button:
• Closes the application.


## Controls

### ObjectsMotion script Overview
The ObjectsMotion script serves as the backbone of the control system, offering a cohesive and user-friendly experience for manipulating various tools.

**Object Position:** The mouse position determines the X and Z positions of the controlled object.

**Object Elevation:** The **W** and **S** keys control the Y position, allowing users to elevate or descend the object.

**Object Rotation:** Holding the **right mouse button** while moving the mouse facilitates object rotation, ensuring a seamless and intuitive control mechanism.

### Usage Instructions

**Object Positioning:**

• Place the mouse at the desired location to set the X and Z positions.

• Utilize the W and S keys for precise control over the object's elevation.

**Object Rotation:**

• Hold down the right mouse button.

• Move the mouse to freely rotate the object.



# Technical Highlights

## Design Patterns Implementation:
• State Pattern: Enumerated states have been employed to define various conditions within the project. This pattern ensures a structured approach to managing different states and enhances the flexibility of the system.

## Unity Cloth Component
Utilizing the Unity Cloth component, this project achieves a realistic interaction with cloth-like objects. The Cloth component is harnessed to deliver authentic deformation and tearing behavior, enhancing the visual and tactile aspects of the gaming experience.

## Mesh Slicing Algorithm
The `Slicer` script contains a detailed algorithm for slicing dynamic objects. It involves the creation of a cutting plane, intersection calculations with the object's mesh, and the generation of new meshes for the sliced parts. The code emphasizes readability and includes comments to facilitate understanding.

## Untiy version
2020.3.35f1
