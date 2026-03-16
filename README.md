# AprilTag App — README (Updated for Version 4.4.5)

A friendly, step-by-step guide for first-time users and teammates.  
This document explains what every button does, how to get connected, and where to drop screenshots.

---

## 📌 What This App Does

- **Detects AprilTags** in the scene and uses them to anchor / identify real-world items.  
- **Supports multiplayer sessions** – multiple people can join, talk via voice, and see the same tags.  
- **Provides a Control Panel** with common actions: join, voice, browser, cameras, BOM lists, etc.  
- **Includes an in-app web browser** (Vuplex) for dashboards and documentation.  
- **Video Recording** – capture and upload video recordings to Opal MS server.
- **Runs on Meta Quest** (with a lightweight Windows companion build for voice chat).  

---

## 🚀 Quick Start (Quest)

1. Put on the headset and launch the app.
2. First is the **Main Panel**: you can see the existing Rooms created.

   ![image](readme_assets/image38.png)
3. Tick the Names you want to tag on Slack in the **panel** on the right.

   ![image](readme_assets/image39.png)
4. i) After the names are selected press **Create Session** to create a session.

   ![image](readme_assets/image41.png)
   
   OR
   
   ii) You can join the created room by pressing the Join button.

   ![image](readme_assets/Image61.png)

5. If Photon is not connected press **Reconnect Photon** to reestablish connection with Photon.

   ![image](readme_assets/image40.png)

   If it still shows "Connecting" then restart the app and check your network.

6. **Bypass Photon** *(New Feature)*  
   If Photon is down and you need to use the app without multiplayer features, press the **Bypass Photon** button. This allows you to join the second scene directly. Note that Photon communication (voice, multiplayer sync) will not work, but tag detection and all other features will function normally.
![image](readme_assets/image78.png)
   After Session is created you will be in the next scene.

---

## 🏷️ AprilTag Detection Scene

This screen provides the main controls and live monitoring features for AprilTag detection and ERP interaction. To start detection, press the **A button**; to stop detection, press the **B button**. You can see the current state in the Tag Detection Status indicator.

![image](readme_assets/image62.png)
![image](readme_assets/Image70.png)

### Main Panel Controls

1. **BOM List Panel**  
   Displays the selected BOM and Wire Mode options.

2. **Tag Detection Status**  
   Indicates whether tag detection is **running** or **stopped**.

3. **Detection Mode Selector**  
   When you select a mode (BOM, Fastener, Drawer, Wire, eBay Pickup List, or Custom Tag Detection), only the corresponding dropdown or input becomes active and the others are non-interactable. In Global Tag Detection mode there is no dropdown; after selecting this mode, press A to start tag detection and B to stop it.
   ![image](readme_assets/image71.png)

4. **Live Video Stream**  
   Displays the camera feed used for AprilTag detection in real time.

5. **Mode-Specific Dropdowns**

   i. **BOM & Wire dropdowns** – These show the CSV file names that you configured in the BOM Link & Manager app. When you select a file in BOM or Wire mode, the related items are shown in the panel next to the live stream. After selecting, press A to start detecting only the tags listed in that file, and press B to stop detection.
   
   ii. **Fastener & Drawer dropdowns** – Here you select a specific Tag ID. After choosing the Tag ID and pressing A, detection starts for that particular tag. Once that tag is detected, detection will stop automatically. If you want to stop before it is detected, press B to stop detection manually.
   
   iii. **eBay Pickup List Mode** – Detects tags whose Tag IDs are present in the eBay pickup list. See the [eBay Pickup List Table](#ebay-pickup-list-table) section for details.
   
   iv. **Custom Tag Detection Mode** – Enter a specific Tag ID in the text box and press A to detect that particular tag. The location and ERP status for that tag will be displayed.
   ![image](readme_assets/image79.png)

7. **Refresh All**  
   Reloads the latest inventory and ERPNext data from the server (BOM, Wire, Fastener, Drawer, and ERP data).

8. **Reset Picking** (BOM & Wire modes only)  
   Once a tag is marked as Picked, it will not be detected again until Reset Picking is pressed. After resetting, press Refresh once and the tag will be detected again.

9. **Close All Tags**  
   Closes all open tag detail panels (green, blue, and orange boxes) currently visible in the scene.

10. **IP Address**  
   Auto-filled by default with the server IP address.

11. **ERP Search**  
    Opens an ERP item search panel where you can:
    - Scroll through the initial ERP item list  
    - Type an item name to filter results  
    - View each item's tag ID, item name, and **location in office**  
    - Press the mic icon to speak the item name (your voice is converted to text in the search box)
    ![image](readme_assets/Image72.png)

12. **Message to Slack**  
    Opens a panel to send a custom message to the configured Slack channel.
    ![image](readme_assets/image73.png)

13. **Mute Button**  
    Toggles microphone input on or off.

14. **Anchor to World**  
    Locks the control panel to the world so it no longer follows your head movement.

15. **Update Location**  
    When tags are detected in Global Tag Detection mode, opens the location update panel:
    - **Input Text Box** – Enter the new location
    - **Mic Icon** – Press to activate voice-to-text; speak the location and press again to stop
    - **Update to ERP** – Sends the new location to ERPNext
    - **Status Text** – Shows success or failure status
    - **Detected Tag ID** – Confirms which tags will be updated
    ![image](readme_assets/Image74.png)

16. **Browser**  
    The embedded browser lets you open internal tools and web pages directly inside the XR app.
    - **Back / Forward / Go** – Standard browser navigation controls
    - **Address Field** – Enter a URL and press **Go** to load the page
    - **Refresh** – Reloads the current page
    - **Close** – Closes the current browser panel

    Quick shortcut buttons:
    - **Opal-MS** – Opens the Opal-MS desktop view
    - **Drive** – Opens your configured file storage / drive
    - **Apsara Dashboard** – View other players' video streams
    - **Team Meeting / Jira** – Opens the team meeting or Jira page
    - **GitHub** – Opens the configured GitHub repository

    ![image](readme_assets/Image75.png)

17. **Send Image**  
    Captures a snapshot from the live video stream and sends it to Opal-MS. The sending status is displayed on the right side after you press the button.

18. **Reconnect Voice**  
    Reconnects the voice assistant if the voice service becomes disconnected.

---

## 🎮 Controller & Pen Button Functions

### Controller Buttons

| Button | Function |
|--------|----------|
| **A Button (Right)** | Starts tag detection |
| **B Button (Right)** | Stops tag detection |
| **Menu Button (Left)** | Opens status view showing BOM and ERP mode selection. Press B in this view to capture an image and send it to GPT for analysis; results are displayed on screen |

### MX Ink Pen Buttons

| Button | Function |
|--------|----------|
| **First Button** | Starts/stops distance measurement. Press once to start measuring, press again to stop. The measurement length is displayed at the center |
| **Third Button** | Activates pen-based tag detection. After selecting a tag mode, press this button to detect the tag closest to the pen tip position |

---

## 📦 Tag Detection Boxes

When an AprilTag is detected, an information box appears over the detected tag. The box type and available actions depend on the selected mode.

### i) BOM & Wire Modes (Green Box)

In **BOM** and **Wire** modes, a **green box** prefab is spawned over the detected tag.

**Information displayed:**
- Name, Tag ID, Quantity, Item Code, Price, Brand, Group
- Location, Office Worker Comment, Project Specific Box No.

**Buttons:**
- **Picked** – Marks the tag as picked (won't be detected again until Reset Picking)
- **Buying Link** – Opens the product/buying link
- **Reprint** – Sends reprint request to Slack
- **Reorder** – Sends reorder request to Slack
- **Close All Except This** – Closes all other boxes
- **Close** – Closes this green box

![image](readme_assets/Image65.png)

### ii) Fastener, Drawer & Global Tag Modes (Blue Box)

In **Fastener**, **Drawer**, and **Global Tag Detection** modes, a **blue box** prefab is spawned.

**Information displayed:**
- Name, Tag ID, Quantity, Item Code, Price, Brand, Group, Location

**Buttons:**
- **Buying Link** – Opens the product/buying link
- **Reprint** – Sends reprint request to Slack
- **Reorder** – Sends reorder request to Slack
- **Send Image to ERP** – Captures and uploads image to ERP and Opal-MS
- **Close All Except This** – Closes all other boxes
- **Close** – Closes this blue box

![image](readme_assets/Image66.png)

### iii) eBay Pickup List Mode (Orange Box) *(New Feature)*

In **eBay Pickup List** mode, an **orange box** prefab is spawned over detected tags.

**Information displayed:**
- Item Name, Tag ID, Quantity, Item Code, Status, Location in Office
![image](readme_assets/image81.png)
**Controls:**
- **Status Dropdown** – Options: Picked, Not Picked, Packed, Out of Office. Changing the status updates ERP automatically
- **Close** – Closes this orange box

---

## 📋 eBay Pickup List Table *(New Feature)*

When eBay Pickup List mode is selected, a table panel appears showing all items in the pickup list.

**Table Columns:**
- Item Code
- Item Name
- Tag ID
- Location in Office
- Order Quantity
- Status
- Buyer
- Order Date

**Features:**
- **Show Out of Office Toggle** – When OFF (default), items with "Out of Office" status are hidden. When ON, all items are displayed
- **Status Dropdown per Row** – Change item status directly from the table; updates ERP automatically
- **Auto-Remove** – If "Show Out of Office" is OFF and status changes to "Out of Office", the row is automatically removed
- **Header Summary** – Shows total item count (e.g., "eBay PICKUP LIST — 15 items")
![image](readme_assets/image80.png)

---

## 🎬 Video Recording Panel *(New Feature)*

Record and upload video from the passthrough camera.

**Controls:**
- **Record Button** – Start/stop recording
  - Blue = Idle (shows "Record")
  - Red = Recording (shows "Stop")
  - Orange = Uploading

**Status Display:**
- "Ready to record"
- "Recording... (X frames)" – Updates every 10 frames
- "Packing X frames..." – During ZIP compression
- "Uploading X.X MB..." – During upload
- "Done! Video saved on PC." – On success

**Process:**
1. Press Record to start capturing frames (default 10 FPS, 960px width)
2. Press Stop to end recording
3. Frames are automatically packaged into a ZIP archive
4. ZIP is uploaded to the Opal MS server
5. Button becomes non-interactable during upload

---

## 🎙️ Voice & Status

- **Voice: Connected / Disconnected** – Photon Voice status
  ![image](readme_assets/image14.png)  
  ![image](readme_assets/image6.png)

- **Mute** – Mic toggle
  - Shows **Mute** when mic is on (tap to mute)
    ![image](readme_assets/image5.png)  
  - Shows **Unmute** when mic is off (tap to unmute)
    ![image](readme_assets/image27.png)  

> 🔒 Mute state is enforced every frame — other scripts can't override it.

---

## 🖐️ Interaction – Grabbing Panels

On the **Main Panel** and **Browser Panel**, you can see a small header/handle bar.  
You can **grab this bar with your VR controllers** to move or reposition the panels in the scene.

![image](readme_assets/Image76.png)
![image](readme_assets/Image77.png)

---

## 👥 Multiplayer & Voice

- Everyone in the same voice session can talk and see the shared experience.
- The **player counter** shows how many are connected.
- If you can't hear others:
  - Press **Reconnect Voice**
  - Double-check your **Mute button**

---

## 🛠️ Troubleshooting

| Issue | Solution |
|-------|----------|
| **Browser links not clickable** | Use the trigger button. Ensure ray pointer includes the UI layer |
| **Voice shows Disconnected** | Press Reconnect Voice. Check Wi-Fi. Verify player count increments |
| **No tags detected** | Increase lighting, reduce glare. Move closer to the tag. Verify tag quality and size. Refresh BOMs and re-select |
| **Photon not connecting** | Press Reconnect Photon. If still failing, use Bypass Photon for offline mode |
| **Video upload failing** | Check network connection. Verify server URL is correct |

---

## 🖥️ AprilTag App — Windows Companion

The Windows app is a **lightweight voice companion**.

Open `Apriltagwindows.exe`.

### Menu Scene

After the App opens you will be in **Main Menu** Scene.

![image](readme_assets/Image43.png)

You can press **Create Session** to start a session or **Join** any existing room shared by other users.

![image](readme_assets/image41.png)

If you see Photon Status as Connected you are good to go.

![image](readme_assets/Image50.png)

If Photon is not connected you can press **Reconnect Photon** to reestablish connection with Photon.

![image](readme_assets/image40.png)

### Meeting Scene

After joining or creating a session you will be in the Meeting Scene.

![image](readme_assets/Image44.png)

**Controls:**
- **Player Count** – Shows current players in the room (top left)
- **Room Name** – Shows current room name (center top)
- **Switch Mic** – Change audio input device
- **Input Mic** – Shows current microphone
- **Mute/Unmute** – Toggle audio input
- **Transmission Status** – Shows True/False below Mute button
- **Open Meets** – Opens Jitsi for screen sharing to Quest users
- **See Saved Images** – Opens web link to view images sent from headset
- **Drive** – Opens Google Drive with manuals
- **Leave Meeting** – Returns to Menu Scene

**NOTE:** For Jitsi, when it says "Waiting for Moderators To arrive", one person needs to be logged in to join the room and let others join. Users can use any basic account or login with Google.

![image](readme_assets/image60.png)

---

## 📤 Procedure to Upload BOM for VR App

This guide explains how to upload a BOM (Bill of Materials) into the VR app using the BOM CSV Handler tool.

### Upload a BOM

**Step 1:** VNC into NucBoxK7

**Step 2:** Go to: `C:\Users\opal\Documents\APRIL TAG APP BOM`

**Step 3:** Open `1. BOMCSVHandler.exe - Shortcut`

**Step 4:** Use the BOM template at: `C:\Users\opal\Documents\APRIL TAG APP BOM\2. BOM TEMPLATE.csv`

**Step 5:** Click **Load CSV File** and select your BOM `.csv` file

**Step 6:** Save BOM into the VR app:
- **Save to BOM** – For general BOM (project item pickup)
- **Save to Wire BOM** – For wire-related robot information

✅ After clicking Save, you will see a confirmation message.

### View or Delete Existing BOMs

1. Click **List BOMs**
2. **Left side:** General BOMs | **Right side:** Wire BOMs
3. Select a BOM and click **Delete** to remove it

---

## 📝 Version History

| Version | Changes |
|---------|---------|
| 4.2.8 | Added Bypass Photon, eBay Pickup List Table, Orange Box, Video Recording, Custom Tag Detection details |
| 4.2.7 | Initial documented version |

---

*Last updated: February 2026*
