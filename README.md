
# ***0x0E Unity WebXR Project***

# ***GitHub Pages For Project***


## Overview

The goal of this project is to develop an immersive bowling experience using WebXR technology. This experience should run in a VR headset browser but also provide fallback keyboard/mouse controls when viewed on a computer. The experience will be hosted on a web page, making it accessible to a larger audience without needing to download and install executable files.

WebXR is a rapidly evolving technology, and for this project, we will be utilizing Unity 2022 LTS along with the WebXR Exporter for Unity. We will be importing several assets to create a bowling alley scene that works across both VR and browser environments.

This project will focus on integrating WebXR to create an interactive and immersive experience that users can access via their browser or VR headset.

## What You Will Learn

By the end of this project, you should be able to explain the following concepts:

- **WebGL**: What it is and how it powers web-based 3D and 2D graphics.
- **Polyfill**: What it is and how it helps make WebXR work across different devices.
- **WebXR**: What it is and its purpose in enabling immersive experiences on the web.
- **Deploying for WebGL from Unity**: How to set up and build Unity projects for WebGL.
- **WebXR Controllers**: How to implement input systems for VR and keyboard/mouse.
- **OpenUPM**: Understanding the OpenUPM package registry and its role in Unity development.
- **Interaction Design**: Designing user interactions for both VR and non-VR experiences.

## Prerequisites

1. **Unity 2022 LTS**: Make sure you are using Unity 2022 LTS for this project. Ensure you have the URP 3D template selected.
2. **WebXR Exporter for Unity**: Install the WebXR Exporter and WebXR Interactions packages via Git or OpenUPM.
3. **WebGL**: Ensure your Unity installation supports WebGL builds.
4. **GitHub Pages or Web Hosting**: For project submission, use GitHub Pages or any other web hosting service to deploy your WebGL project.

## Setup Instructions

1. **Create a New Unity Project**:
   - Use Unity 2022 LTS with the URP 3D template.
   - Set your Build Settings to WebGL.
   
2. **Import WebXR Exporter**:
   - Import the WebXR Exporter and WebXR Interactions packages either via Git or OpenUPM.
   - Follow the official documentation to set up the WebXR environment.

3. **Assets to Include**:
   - SpaceBowlingBar
   - Ball Loader (ProBuilder required)
   - Bowling Pins
   - Bowling Balls
   - Obstacle

Feel free to expand your scene with additional assets.

4. **Build and Test**:
   - Make sure to test your project in both VR and browser environments regularly.

## Tasks Overview

### 0. Setting the Scene

- Create a bowling alley scene with the assets listed above.
- Ensure the scene can render in both VR and a browser.
- Enable users to enter/exit VR mode if supported by the browser.

### 1. Preparing the Interactions

- Implement object interactions, allowing the user to grab and move the bowling balls.
- Ensure that these interactions work in both VR and browser modes.

### 2. Controlling Movements

- Script the bowling ball movement, enabling it to move left and right in the bowling alley using either VR controller or keyboard input.

### 3. Slippery Floor

- Add a physical material to the bowling alley and bowling balls to simulate slipperiness.
- Make each ball have a unique mass.

### 4. Speed-up Pads

- Add at least two speed boost pads in the scene.
- Script them to temporarily speed up the bowling ball when crossed.

### 5. Infinite Spawner

- Create a spawn system that generates obstacles at runtime within the bowling alley.
- Ensure obstacles don't overlap and spawn when the ball touches the alley.

### 6. Scoreboard

- Create a new Canvas gameObject and a score display (scoreTMP).
- Increment the score each time a pin falls.

### 7. Steady Cam

- Script the camera to zoom in/out when the Up/Down Arrow keys are pressed.
- Make the camera rotate left/right based on mouse movement.

### 8. Cinematic Transition

- Create an animation to move and rotate the camera when the player throws the bowling ball.
- Ensure that the camera starts and stops at the same position to avoid discomfort in VR.

### 9. Building the Experience

- Build and upload your WebGL project to GitHub Pages or any other hosting platform.
- Add instructions for interacting with the scene in the HTML file.

## Requirements

- Unity 2022 LTS with URP 3D template.
- WebXR Exporter for Unity (via Git or OpenUPM).
- GitHub repository to store your project.
- Proper documentation in your scripts (XML tags for public classes, comments for private ones).

## Deployment Instructions

1. **Build the WebGL Project**:
   - Build your project for WebGL in Unity.
   - Upload the build files to your GitHub repository or another web hosting service.
   
2. **Set up GitHub Pages**:
   - Enable GitHub Pages for your repository and deploy the build to it.
   
3. **Add Instructions**:
   - Add clear instructions in your HTML page on how to interact with the bowling experience.

## Conclusion

By completing this project, you will gain hands-on experience with Unity's WebGL export, WebXR technology, and designing immersive experiences for the web. You'll also understand how to build a cross-platform project that works in both VR and traditional browser environments.

## Links

- **GitHub Repository**: [https://github.com/Bmontezuma/0x0E-unity-webxr](https://github.com/Bmontezuma/0x0E-unity-webxr)
- **WebGL Build**: Add your web link here after deploying.



