import cv2
from pupil_apriltags import Detector
import json
import os
import numpy as np


image_path = "C:/GOG Games/April Tag Detection/Assets/CapturedFrame.png"
frame = cv2.imread(image_path)

if frame is None:
    print(" Failed to load image.")
    exit(1)


gray = cv2.cvtColor(frame, cv2.COLOR_BGR2GRAY)


at_detector = Detector(families='tag36h11')
tags = at_detector.detect(gray)


output_path = os.path.join(os.path.dirname(__file__), 'tagdata.json')
if not tags:
    print("️ No AprilTags detected.")
    with open(output_path, 'w') as f:
        json.dump({"tag_id": -1}, f)
else:
    tag = tags[0]  
    print(" AprilTag Detected - ID:", tag.tag_id)

    # Save tag ID and corners
    tag_data = {
        'tag_id': tag.tag_id,
        'corners': tag.corners.tolist()
    }
    with open(output_path, 'w') as f:
        json.dump(tag_data, f)

    # Draw tag border and ID
    corners = tag.corners.astype(int)
    colors = [
        (0, 0, 255),     
        (255, 0, 0),    
        (255, 0, 0),    
        (0, 255, 0)      
    ]
    for i in range(4):
        pt1 = tuple(corners[i])
        pt2 = tuple(corners[(i + 1) % 4])
        cv2.line(frame, pt1, pt2, colors[i], 8)

    center = tuple(np.mean(corners, axis=0).astype(int))
    text_pos = (center[0] - 30, center[1])
    cv2.putText(frame, str(tag.tag_id), text_pos,
                cv2.FONT_HERSHEY_SIMPLEX, 3, (255, 255, 255), 10)

    cv2.imwrite(image_path, frame)
    print(" Output image saved with drawn tags.")
