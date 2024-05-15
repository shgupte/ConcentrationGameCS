using System;

public class SingledInput {

    private bool lastPress = false;
    private bool thisPress = false;
    private Func<bool> press;
    public SingledInput(Func<bool> press) {
        this.press = press;
    }

    /** Note that this function should only be used once per loop; otherwise it will return false on all uses after 1; this will be fixed later.*/
    public bool Get() {
        bool p = press();
        if ((!lastPress) && (p)) {
            thisPress = true;
            lastPress = true;
        } else if ((lastPress) && (p)) {
            return false;
        } else if ((lastPress) && (!p)) {
            thisPress = false;
            lastPress = false;
        } 
        return thisPress;
    }

}

