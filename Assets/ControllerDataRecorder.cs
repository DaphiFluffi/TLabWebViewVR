using System.IO;
using UnityEngine;

public class ControllerDataRecorder : MonoBehaviour
{
    public OVRCameraRig ovrCameraRig;
    private bool isRecording = false;
    private StreamWriter writer;
    private string dataFilePath;

    void Update()
    {
        if (isRecording)
        {
            RecordControllerData();
        }
    }

    public void StartRecording()
    {
        string timestamp = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
        dataFilePath = Application.persistentDataPath + "/controller_data_" + timestamp + ".txt";
        writer = new StreamWriter(dataFilePath, true);
        isRecording = true;
        Debug.Log("Recording started");
    }

    public void StopRecording()
    {
        isRecording = false;
        if (writer != null)
        {
            writer.Close();
            writer = null;
        }
        Debug.Log("Recording stopped");
    }

    private void RecordControllerData()
    {
        if (ovrCameraRig == null)
        {
            Debug.LogError("OVRCameraRig is not assigned.");
            return;
        }

        Transform leftController = ovrCameraRig.leftHandAnchor;
        Transform rightController = ovrCameraRig.rightHandAnchor;

        string timestamp = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
        string data = string.Format(
            "{0}, Left Controller Position: {1}, Left Controller Rotation: {2}, Right Controller Position: {3}, Right Controller Rotation: {4}",
            timestamp,
            leftController.position,
            leftController.rotation.eulerAngles,
            rightController.position,
            rightController.rotation.eulerAngles
        );

        writer.WriteLine(data);
    }


}