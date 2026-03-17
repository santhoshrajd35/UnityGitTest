# Apsara Mission Manager — User Readme (Version 1.53)

This app is used to control and operate machines and robots using many types of configurations such as Teleop Controls, 8-Axis Stepper control, managing Firmwares, deploying firmware on machines, real-time measurement, voice collaboration, and web browsing — all from the XR headset.

---

## Features Overview

- [April Tag Panel](#april-tag-panel)
- [TCP Control & Teleop Panel](#tcp-and-teleop-control-panel)
- [Teleop Driving Panel](#teleop-driving-panel)
- [Scanning a Robot Tag](#scanning-a-robot-tag)
- [Grafana Alerts Log](#grafana-alerts-log)
- [8-Axis Machine Panel](#8-axis-machine-panel)
- [Measurement Tool](#measurement-tool)
- [Voice Chat](#voice-chat)
- [Web Browser Panels](#web-browser-panels)
- [Screen Sharing](#screen-sharing)
- [ERP / Inventory Viewer](#erp--inventory-viewer)
- [Auto-Update (OTA)](#auto-update-ota)
- [Typical Session Flow](#typical-session-flow)

---

## April Tag Panel

The April Tag Panel is the main hub of the app. From here you can open all other panels and features.

- Press **Open TCP & Teleop Panel** to open the robot control panel.
- Press **Open 8 Axis Panel** to open the machine axis control panel.
- Press **Scan Robot** to identify a robot by looking at its AprilTag.
- Press **Open Grafana Logs** to view infrastructure and robot alerts.
- Press **Open Browser** to open a web browser panel.
- Press **Measurement Tool** to enter measurement mode.

---

## TCP and Teleop Control Panel

![image](images/image%20(11).png)

On the main April Tag Panel press **Open TCP & Teleop Panel** to open the panel.

![image](images/image%20(1).png)

- **Server connection fields**
  - Server IP and Port (top of the panel) to connect to the central `robot_control` server.
  - IP will be of the server on which the control scripts are running, usually **10.11.16.50**
  - Port will be default **1234**
- **Robot dropdown**
  - A "Select robot" dropdown listing all robots pulled from the Robot Directory / `robot_resolver` (`/robots` endpoint).
- **Alias and IP fields**

  ![image](images/image%20(5).png)

  - Robot alias/name.
  - IP for teleop.
  - Port for teleop, usually **9035** for most robots.
- **Buttons**
  - **Power On / Power Off** (with a confirmation popup so you don't toggle power by accident).
  - **Teleop On / Teleop Off**
  - **Update FW** (firmware)
  - **Config FW** (open firmware configuration panel)
  - **Add host** (add a new host to the backend config).

    ![image](images/image%20(6).png)

- **Log area & heartbeats**
  - A scrolling list of log lines showing what commands were sent and responses coming back.
  - A small heartbeat "LED" that blinks to show the server is alive.
  - Press **Clear Logs** to clear the log window.

### Basic Workflow

![image](images/image%20(2).png)

1. **Connect to the control server**
   - Enter server IP and port (these are usually pre-filled).
   - Press **Connect**.
   - Status should change to "Connected" and the server heartbeat LED will start pulsing.

![image](images/image%20(3).png)

2. **Load and choose a robot**
   - Press **Refresh robots** to fetch the latest list from the Robot Directory.
   - Use the dropdown to pick your robot; alias and IP fields will auto-fill.
   - (If you already scanned a tag earlier, these fields may already be filled in.)

3. **Power control**

![image](images/image%20(15).png)

   - Press **Power On**; you'll see a confirmation dialog.
   - Confirm to send the power-on command to the backend.
   - Use **Power Off** when you're done; again, confirm before it sends.

4. **Teleop control**
   - Press **Teleop On** to start teleoperation for that robot.
   - Press **Teleop Off** to stop teleoperation.

5. **Firmware**

![image](images/image%20(13).png)

   - Press **Update FW** to trigger a firmware deploy for the selected robot.

![image](images/image%20(14).png)

   - Press **Config FW** to open a panel where you can see and change firmware settings for that robot, then send them back to the backend.

All commands you send (power, teleop, firmware) are logged in the log window so you can always see what happened and when.

---

## Teleop Driving Panel

![image](images/image%20(4).png)

Once teleop is enabled for a robot, the **Teleop Panel** lets you drive it with your VR controllers.

### What You See

- **Three sliders**:
  - **X** (side-to-side),
  - **Y** (forward/back),
  - **Yaw** (rotation).
- **Toggle switches**:
  - **AccelCtrl** – whether acceleration control is ON or OFF on the robot.
  - **Thumbstick control** – whether thumbsticks drive the sliders automatically.
- **Mapping toggles**:
  - Invert X, Invert Y, Invert Yaw (for matching how the robot is wired).
- **Speed and status text**:
  - **Velocity** value (how fast the robot moves overall).
  - Status line (e.g., "Idle") and small readouts showing the last values actually sent to the robot for each axis.

### How to Drive

1. Make sure **Teleop enabled** is ON.
2. Use the **left thumbstick** to move:
   - Left/right → X axis
   - Forward/back → Y axis
3. Use the **right thumbstick** left/right to control **Yaw** (turning).
4. Adjust the overall speed (on the Quest left hand controller):
   - Press **Y** to **increase** speed.
   - Press **X** to **decrease** speed.
5. When you want to stop:
   - Turn Teleop OFF from the Teleop panel or from the main Mission Manager panel.
   - Or hit a "Stop"/zero button (if present) to zero the sliders and send a "Stopped" status.

The panel always shows what was really sent to the robot for X, Y, and yaw so you can confirm your commands matched your joystick input.

---

## Scanning a Robot Tag

You can select a robot simply by looking at its AprilTag.

### How It Works

![image](images/image%20(17).png)

When you press the **Scan Robot** button, the app:
- Sends the current camera frame to the AprilTag detection service.
- Waits briefly for detection.
- Reads the detected tag from the tag relay and asks the Robot Directory / `robot_resolver` which robot that tag belongs to.

![image](images/image%20(16).png)

- Shows a **confirmation popup** with the robot's name and IP.
- When you press **Yes**, that robot's IP is applied to the Mission Manager connection config so all panels use the correct robot.

> **NOTE:** Only tags uploaded to MongoDB in the Robots database will be detected by this method.

### How to Use (in the headset)

1. Look at the robot's AprilTag so it's clearly visible in your passthrough view.
2. Press the **Scan Robot** button in the UI to start a scan.
3. A popup will appear with the robot name and IP.
4. Confirm to bind the Teleop Mission to that robot.

If no tag is detected, the scan simply does nothing and shows a short status message instead of applying a wrong robot.

---

## Grafana Alerts Log

![image](images/image%20(19).png)

Mission Manager can show infrastructure and robot alerts (especially battery alerts) from your monitoring system.

### What It Shows

- A scrollable list of recent alerts coming from the `webhook_service` `/vr/alerts` endpoint.
- Each line includes:
  - Time,
  - Status (firing / resolved),
  - Alert title,
  - Robot or machine name if available,
  - Optional summary text.
- Battery alerts are highlighted in a different color so they stand out.

### How to Use

![image](images/image%20(18).png)

1. Press the **Open Grafana Logs** button in the UI to show the panel.
2. The list will automatically refresh every few seconds and append new alerts at the bottom.
3. Scroll the list to review older alerts.
4. Press **Close** when you're done; the panel hides but keeps its state in memory.

---

## 8-Axis Machine Panel

![image](images/image%20(12).png)

On the Main April Tag Panel press the **Open 8 Axis Panel** button to open the panel.

![image](images/image%20(7).png)

The 8-Axis Machine Panel lets you control up to **eight motion axes** (for example lifts, conveyors, forks, or actuators) on a selected machine from inside your XR headset.

You use it to:

- Pick which machine you want to talk to
- See which axes that machine has (stepper / actuator / forklift)
- Move individual axes with position, speed, and acceleration controls
- See live feedback like limit switches and step counts

---

### Choosing a Machine

At the top of the panel you'll see a **Machine dropdown** and some connection fields.

![image](images/image%20(8).png)

- **Machine dropdown** – shows the list of machines fetched from the backend.
- **Host** – the IP (or hostname) of the motion controller for that machine.
- **Port** – the TCP port used for axis control, usually **2244** for most machines.
- **Status text** – a small line showing things like "Loading machines…" or "Loaded 5 machines".
- **Refresh button** – reloads the machine list from the server.

**How to use it:**

1. When the 8-Axis panel opens, it automatically refreshes the machine list.
2. If needed, press **Refresh machines** to force a reload.
3. Open the **Machine dropdown** and choose the machine you want (e.g. "ASRS-62" or "Forklift-01").
4. After you select a machine, the **Host** and **Port** fields auto-fill.

---

### Axis Cards (Per-Axis Controls)

Below the machine picker you'll see up to **eight axis cards** – one for each axis the machine exposes.

![image](images/image%20(9).png)

Each card typically represents one motion axis, such as "Lift", "Rotate", "Fork", "Arm X", etc.

**What you see on each axis card:**

- **Axis name** – e.g. "Axis 0 – Lift", "Axis 1 – Rotate".
- **Inputs**:
  - **ACC** – acceleration (how quickly the axis ramps up).
  - **VEL** – velocity (how fast it moves).
  - **POS** – position (target location).
  - **Limits** – turn hardware limit protection ON or OFF.
- **Buttons**:
  - **Move** – sends the move command using the current ACC / VEL / POS settings.
  - **Stop** – immediately stops that axis.
  - **Enable / Disable** – turns the axis drive on or off (motor enable).
  - **Invert POS** – flips the sign of the position field if you need to move in the opposite direction.
- **Indicators**:
  - Limit switch LEDs – show when limit 1 / limit 2 are hit.
  - Encoder status – whether encoder is enabled on that axis.
- **Readouts**:
  - **Steps** – current position or steps reported by the controller.

**Typical move workflow:**

1. Pick the machine in the dropdown so axis cards are filled with defaults.
2. On the axis you want, check or adjust **ACC**, **VEL**, and **POS**.
3. Press **Enable** if the axis drive is not already on.
4. Press **Move** to start the motion.
5. Watch the **limit indicators** and readouts to confirm the move behaved as expected.
6. Press **Stop** if you need to halt that axis quickly.

---

### Different Axis Types (Stepper, Actuator, Forklift)

The panel supports multiple axis types:

- **Stepper axes** – standard motion axes; these use the full ACC / VEL / POS controls and feedback.
- **Actuator panels** – optimized for simple extend/retract motions. *(In development)*
- **Forklift panels** – used for forklift-style controls (lift, tilt, fork movement). *(In development)*

When you pick a machine, the panel reads the machine's axis configuration from the backend and turns on the correct panel type for each axis.

---

### Common Controls (Working with Multiple Axes at Once)

Below the Connection Control card there is a **Common Controls** row that lets you act on several axes at the same time.

![image](images/image%20(10).png)

**Axis selection:**
- Each axis card has a small **checkbox** — tick the boxes for the axes you want to control together.

**Buttons in the Common Controls bar:**

- **Select All / Deselect All** – toggles all axis checkboxes on or off in one click.
- **Enable All / Disable All** – turns motor enable ON or OFF for all axes at once. Use this to arm or disarm the entire machine quickly.
- **Invert POS (selected)** – flips the sign of the POS field for every selected axis.
- **Move All (selected)** – sends a move command for all selected axes using their current ACC / VEL / POS values.
- **Stop All (selected)** – sends a stop command to all selected axes.

**In practice:**
1. Choose your machine.
2. Tick the checkboxes for the axes you care about.
3. Use **Invert POS**, **Move All**, or **Stop All** to control that group together.
4. Use **Enable All / Disable All** to arm or safe the whole machine at once.

---

### Typical Session with the 8-Axis Panel

1. Open the **8-Axis Panel** in Mission Manager.
2. Let it load machines, or press **Refresh machines**.
3. Choose your **machine** from the dropdown.
4. Confirm the **Host** and **Port** look correct (they will normally auto-fill).
5. On the axis card you care about: enable the axis, adjust ACC / VEL / POS, then press **Move**.
6. Watch the **limit indicators** to make sure everything behaves as expected.
7. Use **Stop** if you need to halt motion, then **Disable** the axis when you're done.

---

## Measurement Tool

The Measurement Tool lets you place and measure distances between physical points in your environment using your VR controller or stylus.

### How to Use

1. Press **Measurement Tool** on the main panel to enter measurement mode.
2. Point at a surface and press the trigger (or stylus tip) to **place a measurement point**.
3. Place a second point — the app will draw a line between them and show the distance.
4. Continue placing points to build up a set of measurements.
5. Use **Undo** (Y button on left controller) to remove the last point if you made a mistake.
6. Press **Clear** to remove all measurements and start fresh.

### Notes

- Measurements are displayed in the headset as floating labels.
- The undo system supports multiple levels — you can undo one step at a time.
- Measurement data stays in the session until you clear it or leave.

---

## Voice Chat

Mission Manager includes built-in voice chat so your team can communicate while working in the same session.

### Controls

- Your microphone is **active by default** when you join a session.
- Press the **Mute** button in the wrist menu or the voice panel to toggle your mic on/off.
- A **mute status dot** is visible on your wrist panel so you always know if you're muted.
- **Player count** is shown in the wrist panel so you can see how many people are in the session.

### Audio Features

- **Echo cancellation** is active automatically to reduce feedback.
- **Remote voice ducking** — background audio from other panels lowers automatically when someone speaks.
- If you experience audio issues, use the **Sound Settings** button to adjust mic and speaker settings.

---

## Web Browser Panels

Mission Manager can open in-headset web browser panels powered by Vuplex WebView.

### How to Use

1. Press **Open Browser** on the main panel or from a relevant feature panel.
2. A browser panel will appear in front of you — you can look up documentation, dashboards, or any web page.
3. Use your controller ray pointer to interact with the browser (click, scroll, type via the VR keyboard).
4. Press **Close** or the close button on the panel to dismiss it.

### Notes

- Browser panels can be repositioned by grabbing and moving them.
- Cookies and session data are persisted between app launches, so you typically stay logged in.
- Multiple browser panels can be open at the same time.

---

## Screen Sharing

You can share your headset camera view or stream what you see to others in the session.

### How to Use

1. Open the **Screen Sharing** panel from the main menu.
2. Press **Start Streaming** to begin broadcasting your passthrough camera view.
3. Other users in the session can open the **Watch** panel to view the stream.
4. Press **Stop Streaming** when done.

### Notes

- A cooldown indicator shows between captures to prevent network overload.
- The stream uses your local network — make sure you are on the same network as the other users.

---

## ERP / Inventory Viewer

Mission Manager can connect to your ERP system (ERPNext) to let you look up inventory and item data directly from inside the headset.

### How to Use

1. Open the **ERP Panel** from the main menu.
2. Use the **search bar** to search for items by name or code.
3. Use the **dropdown** to filter by category.
4. Tap an item row to see its details.

### Notes

- Requires your ERP backend to be reachable on the local network.
- Data is fetched live from ERPNext — results reflect current inventory.

---

## Auto-Update (OTA)

Mission Manager supports over-the-air APK updates. When a new version is available, the app will notify you and offer to install it automatically.

### How It Works

1. On startup, the app checks the update server for a newer APK version.
2. If a new version is found, a **notification banner** appears with the new version number.
3. Press **Update Now** to download and install the new APK.
4. The app will restart automatically after installation.

### Notes

- You must be on the same network as the update server.
- The **version number** is shown on the main panel so you always know which version you are running.
- If you dismiss the update prompt, you can trigger a manual check by restarting the app.

---

## Typical Session Flow

1. **Put on the headset** and make sure you are on the same network as the robot backend.
2. **Start Apsara Mission Manager** — the app checks for updates automatically.
3. **Scan the robot tag** (or pick it from the robot list) to bind the app to the correct robot.
4. **Power ON the robot** from the Mission Manager panel (confirm in the popup).
5. **Turn Teleop ON**, then use the **Teleop Panel** to drive the robot.
6. Use the **8-Axis Panel** if you need to control machine axes.
7. Use the **Measurement Tool** if you need to measure distances in the environment.
8. Keep an eye on the **Grafana Log** for any battery or fault alerts.
9. Use **Voice Chat** to communicate with your team.
10. When done, **stop teleop**, **power OFF the robot**, and close the app.
