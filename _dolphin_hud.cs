using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace agartha {

public class _dolphin_hud {

    public Core core;
    public _dolphin_interface di;

    public int[][] cell;
    public int cycle, delay, toggle;

    public void initialize(_dolphin_interface di) {
    
        this.di = di;
        core = di.core;

        cell = new int[11][];

        cell[0] = new int[] { 60, 60, 60, 60, 60, 60, 60, 60, 60, 60 };
        cell[1] = new int[] { 59, 60, 60, 60, 60, 60, 60, 60, 60, 60 };
        cell[2] = new int[] { 59, 59, 60, 60, 60, 60, 60, 60, 60, 60 };
        cell[3] = new int[] { 59, 59, 59, 60, 60, 60, 60, 60, 60, 60 };
        cell[4] = new int[] { 59, 59, 59, 59, 60, 60, 60, 60, 60, 60 };
        cell[5] = new int[] { 59, 59, 59, 59, 59, 60, 60, 60, 60, 60 };
        cell[6] = new int[] { 59, 59, 59, 59, 59, 59, 60, 60, 60, 60 };
        cell[7] = new int[] { 59, 59, 59, 59, 59, 59, 59, 60, 60, 60 };
        cell[8] = new int[] { 59, 59, 59, 59, 59, 59, 59, 59, 60, 60 };
        cell[9] = new int[] { 59, 59, 59, 59, 59, 59, 59, 59, 59, 60 };
        cell[10] = new int[] { 59, 59, 59, 59, 59, 59, 59, 59, 59, 59 };

        delay = 250;

    return; }

    public bool air_meter() {

        if ((di.status & _dolphin_status.breath) != _dolphin_status.breath)
            return true;

        if (cycle >= delay) { toggle ^= 1; cycle = 0; return true; }
            
        
        cycle++;
        
        if (toggle == 1) return true;

    return false; }

    public void render() {

        int index = di.health;

        if (air_meter() == true)
            core.sprite_manager.add(58, 20, 20);

         for (int count = 0; count < 5; count++)
            core.sprite_manager.add(cell[index][count], 40+(10*count), 22);
         for (int count = 0; count < 5; count++)
             core.sprite_manager.add(cell[index][count+5], 40 + (10 * count), 32);

        core.sprite_manager.add(67, 108, 14);

    return; }
}}
