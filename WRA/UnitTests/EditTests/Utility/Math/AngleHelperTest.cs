using System.Collections;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using WRA.Utility.CustomTypes;
using WRA.Utility.Diagnostics;

public class AngleHelperTest
{
    [Test]
    public void AngleRight()
    {
        Assert.AreEqual(0, AngleHelper.GetAngle(Vector2.zero, Vector2.right));
    }
    
    [Test]
    public void AngleUpRight()
    {
        Assert.AreEqual(45, AngleHelper.GetAngle(Vector2.zero, Vector2.one));
    }

    [Test]
    public void AngleUp()
    {
        Assert.AreEqual(90, AngleHelper.GetAngle(Vector2.zero, Vector2.up));
    }
    
    [Test]
    public void AngleUpLeft()
    {
        Assert.AreEqual(135, AngleHelper.GetAngle(Vector2.zero, new Vector2(-1, 1)));
    }

    [Test]
    public void AngleLeft()
    {
        Assert.AreEqual(180, AngleHelper.GetAngle(Vector2.zero, Vector2.left));
    }
    
    [Test]
    public void AngleDownLeft()
    {
        Assert.AreEqual(-135, AngleHelper.GetAngle(Vector2.zero, new Vector2(-1, -1)));
    }
    
    [Test]
    public void AngleDown()
    {
        Assert.AreEqual(-90, AngleHelper.GetAngle(Vector2.zero, Vector2.down));
    }
    
    [Test]
    public void AngleDownRight()
    {
        Assert.AreEqual(-45, AngleHelper.GetAngle(Vector2.zero, new Vector2(1, -1)));
    }

    [Test]
    public void RandomAngleTest()
    {
        var tolerance = 0;
        var randomAngle = Random.Range(-180, 180);
        
        var calculatedRange = AngleHelper.GetAngle(Vector2.zero, AngleHelper.GetDirection(randomAngle));
        
        Debug.Log("Random angle: " + randomAngle);
        Debug.Log("Calculated angle: " + calculatedRange);
        Debug.Log("Tolerance: " + tolerance);
        Assert.IsTrue(randomAngle - tolerance <= calculatedRange && calculatedRange <= randomAngle + tolerance,
            $"Random angle: {randomAngle}, calculated angle: {calculatedRange}, tolerance: {tolerance} degree");
    }

    [Test]
    public void RandomInAngle()
    {
        var tolerance = 0;
        var randomAngle = Random.Range(-180, 180);
        var randomAngleRange = Random.Range(0, 180);
        var correctAnswer = GetCorrectAnswer(randomAngle, randomAngleRange);
        Assert.IsTrue(CheckDirectionAngleWithDebug(randomAngle, randomAngleRange, correctAnswer) == correctAnswer);
    }

    [Test]
    public void AngleTest15()
    {
        var angle = 15;
        var range = 15;
        var correctAnswer = true;
        Assert.IsTrue(CheckDirectionAngleWithDebug(angle, range, correctAnswer) == correctAnswer);
    }
    
    [Test]
    public void AngleTest15ReduceEpsilon()
    {
        var angle = 15;
        var range = 15 - AngleHelper.EPSILON;
        var correctAnswer = false;
        Assert.IsTrue(CheckDirectionAngleWithDebug(angle, range, correctAnswer) == correctAnswer);
    }

    private bool GetCorrectAnswer(float angle, float range)
    {
        return angle <= range && angle >= -range;
    }

    private bool CheckDirectionAngleWithDebug(float angle, float range, bool expected)
    {
        var direction = AngleHelper.GetDirection(angle);
        var lookDirection = Vector2.right;
        var ansewer= AngleHelper.IsInAngle(Vector2.zero, direction, lookDirection, range);
        Debug.Log("Angle: " + angle);
        Debug.Log("Range: " + range);
        Debug.Log("Correct answer: " + expected);

        return ansewer;
    }

}
