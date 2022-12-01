using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Robotics.ROSTCPConnector;
using Unity.Robotics.ROSTCPConnector.ROSGeometry;
using Path = RosMessageTypes.Nav.PathMsg;

public class HeadsetConnection : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        ROSConnection.instance.Subscribe<Path>("/vins_estimator/path", ChangeRotation);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    private void ChangeRotation(Path msgPath)
    {
        var c = msgPath.poses[msgPath.poses.Length - 1];
        Debug.Log(c.pose.ToString());
        var pos = c.pose.position;
        //Vector3<FLU> ROSpos = new Vector3<FLU>((float)pos.x, (float)pos.y, (float)pos.z);
        //Vector3 unityPos = ROSpos.toUnity;
        //this.transform.localPosition = unityPos;
        this.transform.localPosition = new Vector3(-(float)pos.y, (float)pos.z, (float)pos.x);
        //this.transform.localPosition = new Vector3((float)pos.x, (float)pos.y, (float)pos.z);
        //this.transform.localPosition = new Vector3((float)pos.z, -(float)pos.x, (float)pos.y);
        var orientation = c.pose.orientation;
        //Quaternion<FLU> ROSore = new Quaternion<FLU>((float)orientation.x, (float)orientation.y, (float)orientation.z, (float)orientation.w);
        //Quaternion Unityore = ROSore.toUnity;
        //this.transform.localRotation = Unityore;
        this.transform.localRotation = new Quaternion((float)orientation.z,(float)orientation.y,(float)orientation.x, (float)orientation.w);
        //this.transform.localRotation = new Quaternion((float)orientation.y, -(float)orientation.z, -(float)orientation.x, (float)orientation.w);

    }
}
