using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace agartha {


public class _dolphin_action {
            
    public const int up = 0;
    public const int down = 1;
    public const int left = 2;
    public const int right = 3;

    public const int left_charge = 4;
    public const int right_charge = 5;
    public const int up_charge = 6;
    public const int down_charge = 7;

    public const int left_charge_idle = 8;
    public const int right_charge_idle = 9;
    public const int up_charge_idle = 10;
    public const int down_charge_idle = 11;

    public const int jump = 12;

    public const int left_idle = 13;
    public const int right_idle = 14;
    public const int up_idle = 15;
    public const int down_idle = 16;

    public const int left_beached = 17;
    public const int right_beached = 18;
}

public class _dolphin_status {

    public const int disabled = 0x000000;
    public const int enabled = 0xf00000;

    public const int recoil = 0x00000f;
    public const int stunned = 0x0000f0;

    public const int beached = 0x000e00;
    public const int wallop = 0x000f00;

    public const int flop = 0x00f000;
    public const int breath = 0x0f0000;

    public const int identity = 0xf0ffff;

    public const int unknown = 0xf00000;
    public const int charge = 0xf00001;
    public const int jump = 0xf00002;

    public const int charge_wait_sequence = 0xf10001;
    public const int charge_update_velocity = 0xf20001;
    public const int charge_deconstructor = 0xf30001;

    public const int jump_wait_sequence = 0xf10002;
    public const int jump_wait_boundary = 0xf20002;
    public const int jump_inboundary = 0xf30002;
    public const int jump_clear_boundary = 0xf40002;
    public const int jump_deconstructor = 0xf50002;

}

public class _dolphin_interface {

    public Core core;

    public Direction direction;
    public Physics physics;
    public Sequence sequence;

    public int state;
    public int status;

    public int health, air;

    public _dolphin_hud dolphin_hud;

    public _dolphin_state_default dolphin_state_default;
    public _dolphin_state_charge dolphin_state_charge;
    public _dolphin_state_jump dolphin_state_jump;

    public _dolphin_status_stunned dolphin_status_stunned;

}}
