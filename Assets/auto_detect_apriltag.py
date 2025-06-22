import cv2
from pupil_apriltags import Detector

# Initialize camera
cap = cv2.VideoCapture(0)  # Use the working index

# Initialize detector
at_detector = Detector(families='tag36h11')

print(" Camera started, looking for tags...")

while True:
    ret, frame = cap.read()
    if not ret:
        print(" Failed to grab frame")
        break

    gray = cv2.cvtColor(frame, cv2.COLOR_BGR2GRAY)
    tags = at_detector.detect(gray)

    for tag in tags:
        print(f"Detected ID: {tag.tag_id}")

        # Draw border
        for i in range(4):
            pt1 = tuple(map(int, tag.corners[i]))
            pt2 = tuple(map(int, tag.corners[(i + 1) % 4]))
            cv2.line(frame, pt1, pt2, (0, 255, 0), 2)

        # Draw center and ID
        center = tuple(map(int, tag.center))
        cv2.circle(frame, center, 5, (0, 0, 255), -1)
        cv2.putText(frame, f"ID: {tag.tag_id}", (center[0]+10, center[1]),
                    cv2.FONT_HERSHEY_SIMPLEX, 0.6, (0, 0, 255), 2)

    cv2.imshow("AprilTag Detection", frame)

    if cv2.waitKey(1) & 0xFF == ord('q'):
        break

cap.release()
cv2.destroyAllWindows()
