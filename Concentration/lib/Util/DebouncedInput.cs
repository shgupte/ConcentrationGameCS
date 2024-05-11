using System;
using System.Dynamic;
using System.Threading;

public class DebouncedInput {

    private bool lastPress = false;
    private bool thisPress = false;
    private Func<bool> press;
    private Func<bool> release;
    public DebouncedInput(Func<bool> press, Func<bool> release) {
        this.press = press;
        this.release = release;
    }

    private void Set() {
        bool p = press();
        bool r = release();
        if ((lastPress = false) && (p = true)) {
            thisPress = true;
            lastPress = true;
        } else if ((lastPress = true) && (p = false)) {
            thisPress = false;
            lastPress = false;
        } 
    }

    public bool Get() {
        Set();
       // bool temp = thisPress;
        //thisPress = false;
        Console.WriteLine(thisPress);
        return thisPress;
    }

}

