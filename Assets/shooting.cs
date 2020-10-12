using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using UnityEngine;

public class shooting : MonoBehaviour
{
    public Transform ray_dir;
    public float max_distance = 5000f;
    public LineRenderer line;
    public int counter = 0;
    public Transform follow_slime;
    public Array lazer_speedup;
    private bool flash;
    Vector3 thisVelocity = Vector3.zero;
    public float smoothTime = 0.3f;
    private float x;
    private float y;
    private double x1;
    private double y1;
    private float long_x;
    private float long_y;
    public GameObject beam;
    // Start is called before the first frame update
    void Start()
    {
        int going_down = 20;
        int num = 0;
        bool adding = true;
        int add_up = 20;
        List<int> speedup = new List<int>();
        while (num < 220)
        {
            num += 1;
            if (adding == true)
            {
                speedup.Add(num);
            }
            if (num >= add_up && adding == true)
            {
                add_up += going_down;
                adding = false;
            }
            if (num >= add_up && adding == false)
            {
                add_up += going_down;
                if (going_down > 5)
                {
                    going_down -= 3;
                }
                adding = true;
            }
        }
        lazer_speedup = speedup.ToArray();

        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        y = Math.Abs(transform.position.y - ray_dir.position.y);
        x = Math.Abs(transform.position.x - ray_dir.position.x);
        long_y = Math.Abs(transform.position.y - follow_slime.position.y);
        long_x = Math.Abs(transform.position.x - follow_slime.position.x);
        float flong_x = Convert.ToSingle(long_x);
        float flong_y = Convert.ToSingle(long_y);
        double radians = Math.Atan(flong_x / flong_y);
        double degrees = 90-radians * (180 / Math.PI);
        float fdegrees = Convert.ToSingle(degrees);
        beam.transform.rotation = Quaternion.Euler(0, 0, fdegrees);
        y1 = Math.Sqrt(2500 / (x * x / y) + 1);
        x1 = (x / y) * y1;
        float fy = Convert.ToSingle(y1);
        float fx = Convert.ToSingle(x1);
        Ray myRay = new Ray(transform.position, ray_dir.position - transform.position);
        //Debug.DrawRay(myRay.origin, myRay.direction * max_distance, Color.green);
        counter += 1;
        foreach (int num in lazer_speedup)
        {
            if (counter == num)
            {
                flash = true;
                break;
            }
            flash = false;
        }

        if (counter < 220)
        {
            beam.SetActive(false);
            if (flash == false)
            {
                Vector3 targetPosition = ray_dir.TransformPoint(new Vector3(-fx, -fy, -10));
                follow_slime.position = Vector3.SmoothDamp(follow_slime.position, targetPosition, ref thisVelocity, smoothTime);
                //follow_slime.position = ray_dir.position;
                line.SetPosition(1, follow_slime.position);
                line.SetPosition(0, transform.position);
            }
            else
            {
                Vector3 targetPosition = ray_dir.TransformPoint(new Vector3(-fx, -fy, -10));
                follow_slime.position = Vector3.SmoothDamp(follow_slime.position, targetPosition, ref thisVelocity, smoothTime);
                //follow_slime.position = ray_dir.position;
                line.SetPosition(1, transform.position);
                line.SetPosition(0, transform.position);
            }
        }else if (counter > 220 && counter < 320) 
        {
            beam.SetActive(true);
            line.SetPosition(1, follow_slime.position);
            line.SetPosition(0, transform.position);
        }else if (counter > 320 && counter < 500)
        {
            beam.SetActive(false);
            Vector3 targetPosition = ray_dir.TransformPoint(new Vector3(-fx, -fy, -10));
            follow_slime.position = Vector3.SmoothDamp(follow_slime.position, targetPosition, ref thisVelocity, smoothTime);
            line.SetPosition(1, transform.position);
            line.SetPosition(0, transform.position);
        }
        else if (counter > 500)
        {
            counter = 0;
        }


    }
}
