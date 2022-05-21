using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace agartha {

public class _npc_status {

    public const int disabled = 0x000000;
    public const int enabled = 0xf00000;
    public const int expired = 0xe00000;
    public const int suspend = 0xffffff;

    public const int stunned = 0x0000f0;

    public const int npc_foreground = 0x000001;
    public const int npc_surface = 0x000002;
    public const int npc_boundary = 0x000003;
    public const int npc_medusa = 0x000004;
    public const int npc_seanettle = 0x000005;
    public const int npc_seal = 0x000006;
    public const int npc_yellowfin = 0x000007;
}

public class _npc_interface {

    public int parent_id, id;

    public int type, state;
    public double x, y;
    public int width, height;
    public int parameter;

    public void copy(_npc_interface source) {

        parent_id = source.parent_id;
        id = source.id;

        type = source.type;
        state = source.state;

        set_position(source.x, source.y);
        set_dimensions(source.width, source.height);

        parameter = source.parameter;

    return; }

    public _boundary_interface boundary() {

        _boundary_interface boundary = new _boundary_interface();

        boundary.state = state;
        boundary.set_position((int)x, (int)y);
        boundary.set_dimensions(width, height);

    return boundary; }

    public void set_position(double x, double y) {
        this.x = x; this.y = y; 
    return; }

    public void set_dimensions(int w, int h) {
        width = w; height = h;
    return; }
}

public class NPCManager {

    public Core core;
    public ForegroundManager foreground_manager;

    public int x, y;
    public int row, column;
    public int width, height;

    public int[] quadrant;
    public _npc_interface[][] vector;

    public int index, total;
    public _npc_interface[] table;

    public Surface[] npc_surface;
    public NPCMedusa[] npc_medusa;
    public NPCSeaNettle[] npc_seanettle;
    public NPCSeal[] npc_seal;
    public NPCYellowFin[] npc_yellowfin;

    public void initialize(Core core) {

        this.core = core;

        foreground_manager = new ForegroundManager();
        foreground_manager.initialize(core);

        quadrant = new int[4];
        index = 0; total = 64;

        table = new _npc_interface[total];
        npc_surface = new Surface[total];
        npc_medusa = new NPCMedusa[total];
        npc_seanettle = new NPCSeaNettle[total];
        npc_seal = new NPCSeal[total];
        npc_yellowfin = new NPCYellowFin[total];

        for (int count = 0; count < total; count++) {

            table[count] = new _npc_interface();
            npc_surface[count] = new Surface(core);

            npc_medusa[count] = new NPCMedusa();
            npc_medusa[count].initialize(core);

            npc_seanettle[count] = new NPCSeaNettle();
            npc_seanettle[count].initialize(core);

            npc_seal[count] = new NPCSeal();
            npc_seal[count].initialize(core);

            npc_yellowfin[count] = new NPCYellowFin();
            npc_yellowfin[count].initialize(core);
        }

    return; }

    public void set_vector(_npc_interface[][] vector) {

        this.vector = vector;

    return; }

    public void generate_next_id() {
            
        if (index >= 64) return;
        if (table[index].state == 0) return;

        index++;

    return; }

    public void set_position(int x, int y) {

        this.x = x; this.y = y;

        row = x >> 8; column = y >> 8;

        if (row < 0) row = 0;
        if (column < 0) column = 0;

        if (row >= width) row = width-1;
        if (column >= height) column = height-1;

    return; }

    public void set_dimensions(int w, int h) {

        width = w; height = h;

    return; }

    public void add(_npc_interface npc) {

        for (int count = 0; count < table.Length; count++) {

        if (table[count].type == _npc_status.disabled) {

            table[count].copy(npc);
            enable_npc(count);

        return; }}

    return; }

    public void set_quadrant(int id, int row, int column) {

        if ((row >= width) || (column >= height)) {
            quadrant[id] = 0xffffff;
        return; }

        if ((row < 0) || (column < 0)) {
            quadrant[id] = 0xffffff;
        return; }

        int index = (column*width) + row;
        quadrant[id] = index;

    return; }

    public void get_all_quadrants() {

        set_quadrant(0, row, column);
        set_quadrant(1, row+1, column);
        set_quadrant(2, row, column+1);
        set_quadrant(3, row+1, column+1);

    return; }

    public void dispatch_npc(_npc_interface npc) {

        if (npc.type == _npc_status.npc_boundary) {
            core.boundary_manager.add(npc.boundary());
        return; }
             
        if (npc.type == _npc_status.npc_foreground) {
            foreground_manager.add(npc);
        return; }

        if (npc.state != _npc_status.suspend)
            return;
         
        int x = this.x+128;
        int y = this.y+128;

        if ((npc.x+npc.width > x) && (npc.x < x+256))
        if ((npc.y+npc.height > y) && (npc.y < y+256))
            return;

        add(npc);

    return; }

    public void enable_npc(int id) {

        _npc_interface npc = table[id];

        table[id].state = _npc_status.enabled;
        vector[npc.parent_id][npc.id].state = _npc_status.enabled;

    return; }

    public void suspend_npc(int id) {

        _npc_interface npc = table[id];

        table[id].type = _npc_status.disabled;
        vector[npc.parent_id][npc.id].state = _npc_status.suspend;

    return; }

    public bool suspend_boundary(_boundary_interface boundary) {

        if ((boundary.x+boundary.width < x) || (boundary.x > (x+512)))
            return true;

        if ((boundary.y+boundary.height < y) || (boundary.y > (y+512)))
            return true;

    return false; }

    public void process_npc_surface(int id) {

        if (npc_surface[id].state == _npc_status.disabled)
            npc_surface[id].set_component(table[id]);

        _boundary_interface boundary = npc_surface[id].boundary();

        if (suspend_boundary(boundary) == true) {
            suspend_npc(id);
        return; }

        npc_surface[id].process();

    return; }

    public void process_npc_medusa(int id) {

        if (npc_medusa[id].state == _npc_status.disabled)
            npc_medusa[id].set_component(table[id]);

        _boundary_interface boundary = npc_medusa[id].boundary();

        if (suspend_boundary(boundary) == true) {
            suspend_npc(id);
            npc_medusa[id].state = _npc_status.disabled;
        return; }

        npc_medusa[id].process();

    return; }

    public void process_npc_seanettle(int id) {

        if (npc_seanettle[id].state == _npc_status.disabled) {
            npc_seanettle[id].randomize();
            npc_seanettle[id].set_component(table[id]); }

        _boundary_interface boundary = npc_seanettle[id].boundary();

        if (suspend_boundary(boundary) == true) {
            suspend_npc(id);
            npc_seanettle[id].state = _npc_status.disabled;
        return; }

        npc_seanettle[id].process();

    return; }

    public void process_npc_seal(int id) {

        if (npc_seal[id].state == _npc_status.disabled)
            npc_seal[id].set_component(table[id]);

        _boundary_interface boundary = npc_seal[id].boundary();

        if (suspend_boundary(boundary) == true) {
            suspend_npc(id);
            npc_seal[id].state = _npc_status.disabled;
        return; }

        npc_seal[id].process();

    return; }

    public void process_npc_yellowfin(int id) {

        if (npc_yellowfin[id].state == _npc_status.disabled) {
            npc_yellowfin[id].randomize();
            npc_yellowfin[id].set_component(table[id]); }

        _boundary_interface boundary = npc_yellowfin[id].boundary();

        if (suspend_boundary(boundary) == true) {
            suspend_npc(id);
            npc_yellowfin[id].state = _npc_status.disabled;
        return; }

        npc_yellowfin[id].process();

    return; }

    public void dispatch_quadrant(int index) {

        if (index == 0xffffff) return;

        for (int count = 0; count < vector[index].Length; count++)
            dispatch_npc(vector[index][count]);

    return; }

    public void update_quadrant() {

        get_all_quadrants();

        for (int count = 0; count < 4; count++)
            dispatch_quadrant(quadrant[count]);

    return; }

    public void process() {
        
        update_quadrant();

        for (int count = 0; count < table.Length; count++) {

        switch (table[count].type) {

        case _npc_status.npc_surface:
            process_npc_surface(count);
        break;

        case _npc_status.npc_medusa:
            process_npc_medusa(count);
        break;

        case _npc_status.npc_seanettle:
            process_npc_seanettle(count);
        break;
        
        case _npc_status.npc_seal:
            process_npc_seal(count);
        break;

        case _npc_status.npc_yellowfin:
            process_npc_yellowfin(count);
        break;

        }}

    return; }

    public void update() {

        for (int count = 0; count < table.Length; count++) {

        switch (table[count].type) {

        case _npc_status.npc_surface:
            npc_surface[count].update();
        break;
        
        }}

        foreground_manager.update();
        foreground_manager.reset();

    return; }
}}
