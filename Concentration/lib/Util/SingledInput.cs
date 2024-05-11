using System;
using System.Dynamic;
using System.Threading;

public class SingledInput {

    private bool lastPress = false;
    private bool thisPress = false;
    private Func<bool> press;
    private Func<bool> release;
    public SingledInput(Func<bool> press, Func<bool> release) {
        this.press = press;
        this.release = release;
    }

    /** Note that this function should only be used once per loop; otherwise it will return false on all uses after 1; this will be fixed later.*/
    public bool Get() {
        bool p = press();
        bool r = release();
        if ((!lastPress) && (p)) {
            thisPress = true;
            lastPress = true;
        } else if ((lastPress) && (p)) {
            return false;
        } else if ((lastPress) && (r)) {
            thisPress = false;
            lastPress = false;
        } 
        return thisPress;
    }

}

