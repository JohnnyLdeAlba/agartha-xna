using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace agartha {

public class _dolphin_status_stunned {

    _dolphin_interface di;

    int cycle, delay;
    int toggle_cycle, toggle_delay, toggle;

    public void initialize(_dolphin_interface di) {

        this.di = di;

        delay = 1000;
        toggle_delay = 100;

    return; }

    public void update() {

            if (cycle < delay) { cycle++; return; }
            
            cycle = 0;
            di.status &= ~_dolphin_status.stunned;
            
    return; }

    public bool check() {

        if ((di.status & _dolphin_status.stunned) != _dolphin_status.stunned)
            return true;

        update();

        if (toggle_cycle >= toggle_delay) {
            toggle_cycle = 0;
            toggle ^= 1;
        return true; }
            
        toggle_cycle++;
        
        if (toggle == 1) return true;

    return false; }
}}
