using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Media;

namespace agartha {

public class _level_alpha {

    public Core core;

    public BoundaryManager boundary_manager;
    public NPCManager npc_manager;
    public Parallax parallax;
    public Viewport viewport;

    public PlayableKuros playable_kuros;
    public ProjectileSplash projectile_splash;

    public Song background_music;

    public void get_vector_npcmanager() {

        _npc_interface[][] vector = new _npc_interface[2][];

        vector[0] = new _npc_interface[11];

        vector[0][0] = new _npc_interface();

        vector[0][0].type = _npc_status.npc_foreground;
        vector[0][0].state = _npc_status.enabled;
        vector[0][0].parameter = 86;

        vector[0][0].set_position(62, 298);
        vector[0][0].set_dimensions(16, 16);

        vector[0][1] = new _npc_interface();

        vector[0][1].type = _npc_status.npc_foreground;
        vector[0][1].state = _npc_status.enabled;
        vector[0][1].parameter = 80;

        vector[0][1].set_position(72, 304);
        vector[0][1].set_dimensions(16, 16);

        vector[0][2] = new _npc_interface();

        vector[0][2].type = _npc_status.npc_surface;
        vector[0][2].state = _npc_status.suspend;

        vector[0][2].set_position(0, 192);
        vector[0][2].set_dimensions(256, 1);

        vector[0][3] = new _npc_interface();

        vector[0][3].type = _npc_status.npc_boundary;
        vector[0][3].state = _boundary_status.segment;

        vector[0][3].set_position(48, 0);
        vector[0][3].set_dimensions(1, 400);

        vector[0][4] = new _npc_interface();

        vector[0][4].type = _npc_status.npc_boundary;
        vector[0][4].state = _boundary_status.segment;

        vector[0][4].set_position(480, 0);
        vector[0][4].set_dimensions(1, 400);

        vector[0][5] = new _npc_interface();

        vector[0][5].type = _npc_status.npc_foreground;
        vector[0][5].state = _npc_status.suspend;

        vector[0][5].set_position(196, 184);
        vector[0][5].set_dimensions(16, 16);
        vector[0][5].parameter = 79;

        vector[0][6] = new _npc_interface();

        vector[0][6].type = _npc_status.npc_medusa;
        vector[0][6].state = _npc_status.suspend;

        vector[0][6].set_position(100, 194);
        vector[0][6].set_dimensions(100, 100);

        vector[0][7] = new _npc_interface();

        vector[0][7].type = _npc_status.npc_foreground;
        vector[0][7].state = _npc_status.enabled;
        vector[0][7].parameter = 81;

        vector[0][7].set_position(208, 180);
        vector[0][7].set_dimensions(16, 16);

        vector[0][8] = new _npc_interface();

        vector[0][8].type = _npc_status.npc_boundary;
        vector[0][8].state = _boundary_status.segment;

        vector[0][8].set_position(196, 200);
        vector[0][8].set_dimensions(36, 32);

        vector[0][9] = new _npc_interface();

        vector[0][9].type = _npc_status.npc_boundary;
        vector[0][9].state = _boundary_status.wall;

        vector[0][9].set_position(236, 160);
        vector[0][9].set_dimensions(16, 1);

        vector[0][10] = new _npc_interface();

        vector[0][10].type = _npc_status.npc_boundary;
        vector[0][10].state = _boundary_status.segment;

        vector[0][10].set_position(236, 155);
        vector[0][10].set_dimensions(16, 1);

        vector[1] = new _npc_interface[3];

        vector[1][0] = new _npc_interface();

        vector[1][0].type = _npc_status.npc_seal;
        vector[1][0].state = _npc_status.disabled;

        vector[1][0].set_position(236, 130);
        vector[1][0].set_dimensions(40, 40);

        vector[1][1] = new _npc_interface();

        vector[1][1].type = _npc_status.npc_yellowfin;
        vector[1][1].state = _npc_status.disabled;

        vector[1][1].set_position(400, 260);
        vector[1][1].set_dimensions(40, 40);

        vector[1][2] = new _npc_interface();

        vector[1][2].type = _npc_status.npc_surface;
        vector[1][2].state = _npc_status.suspend;

        vector[1][2].set_position(256, 192);
        vector[1][2].set_dimensions(256, 1);

        for (int x = 0; x < vector.Length; x++)
        for (int y = 0; y < vector[x].Length; y++) {

        vector[x][y].parent_id = x;
        vector[x][y].id = y; }

        npc_manager.set_dimensions(2, 1);
        npc_manager.set_vector(vector);

    return; }

    public void get_vector_parallax() {

        int[][] vector = new int[][] {
        
        new int[] {17,  17,  17,  17,  17,  17,  17,  17,  17,  17,  17,  17,  17,  17,  17,  17,
                   17,  17,  17,  17,  17,  17,  17,  17,  17,  17,  17,  17,  17,  17,  17,  17,
                   17,  17,  17,  17,  17,  17,  17,  17,  17,  17,  17,  17,  17,  17,  17,  17,
                   17,  17,  17,  17,  17,  17,  17,  17,  17,  17,  17,  17,  17,  17,  17,  17,
                   17,  17,  17,  17,  17,  17,  17,  17,  17,  17,  17,  17,  17,  17,  17,  17,
                   17,  17,  17,  17,  17,  17,  17,  17,  17,  17,  17,  17,  17,  17,  17,  17,
                   17,  17,  17,  17,  17,  17,  17,  17,  17,  17,  17,  17,  17,  17,  17,  17,
                   17,  17,  17,  17,  17,  17,  17,  17,  17,  17,  17,  17,  17,  17,  17,  17,
                   17,  17,  17,  17,  17,  17,  17,  17,  17,  17,  17,  17,  17,  17,  17,  17,
                   17,  17,  17,  17,  17,  17,  17,  17,  17,  17,  17,  17,  17,  17,  17,  17,
                   17,  17,  17,  17,  17,  17,  17,  17,  17,  17,  17,  17,  17,  17,  17,  17,
                   17,  17,  17,  17,  17,  17,  17,  17,  17,  17,  17,  17,  17,  17,  17,  17,
                   17,  17,  17,  17,  17,  17,  17,  17,  17,  17,  17,  17,  17,  17,  17,  17,
                   17,  17,  17,  17,  17,  17,  17,  17,  17,  17,  17,  17,  17,  17,  17,  17,
                   17,  17,  17,  17,  17,  17,  17,  17,  17,  17,  17,  17,  17,  17,  17,  17,
                   17,  17,  17,  17,  17,  17,  17,  17,  17,  17,  17,  17,  17,  17,  17,  17 },

        new int[] {17,  17,  17,  17,  17,  17,  17,  17,  17,  17,  17,  17,  17,  17,  17,  17,
                   17,  17,  17,  17,  17,  17,  17,  17,  17,  17,  17,  17,  17,  17,  17,  17,
                   17,  17,  17,  17,  17,  17,  17,  17,  17,  17,  17,  17,  17,  17,  17,  17,
                   17,  17,  17,  17,  17,  17,  17,  17,  17,  17,  17,  17,  17,  17,  17,  17,
                   17,  17,  17,  17,  17,  17,  17,  17,  17,  17,  17,  17,  17,  17,  17,  17,
                   17,  17,  17,  17,  17,  17,  17,  17,  17,  17,  17,  17,  17,  17,  17,  17,
                   17,  17,  17,  17,  17,  17,  17,  17,  17,  17,  17,  17,  17,  17,  17,  17,
                   17,  17,  17,  17,  17,  17,  17,  0,   17,  17,  17,  17,  17,  17,  17,  17,
                   17,  17,  17,  17,  17,  17,  17,  17,  17,  17,  17,  17,  17,  17,  17,  17,
                   17,  17,  17,  17,  17,  17,  17,  17,  17,  17,  17,  17,  17,  17,  17,  17,
                   17,  17,  17,  17,  17,  17,  17,  17,  17,  17,  17,  17,  17,  17,  17,  17,
                   17,  17,  17,  17,  17,  17,  17,  17,  17,  17,  17,  17,  17,  17,  17,  17,
                   17,  17,  17,  17,  17,  17,  17,  17,  17,  17,  17,  17,  17,  17,  17,  17,
                   17,  17,  17,  17,  17,  17,  17,  17,  17,  17,  17,  17,  17,  17,  17,  17,
                   17,  17,  17,  17,  17,  17,  17,  17,  17,  17,  17,  17,  17,  17,  17,  17,
                   17,  17,  17,  17,  17,  17,  17,  17,  17,  17,  17,  17,  17,  17,  17,  17 }};

        parallax.set_dimensions(1, 2);
        parallax.set_vector(vector);

    return; }

    public void get_vector_matrix() {

        int[][] vector = new int[][] {
        
        new int[] { 0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,
                    0,   1,   2,   1,   2,   1,   2,   1,   2,   1,   2,   1,   2,   1,   2,   1,
                    0,   3,   4,   1,  16,   9,   9,   9,   9,   9,   9,   9,   9,   9,   9,   9,
                    0,   1,   2,   16,  0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,
                    0,   3,  16,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,
                    0,   1,  15,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,
                    0,   3,  15,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,
                    0,   1,  15,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,
                    0,   3,  15,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,  12,  14,
                    0,   1,  15,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,  10,  16,
                    0,   3,  15,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,
                    0,   1,  15,   0,   0,   0,   0,   0,   0,   0,   0,  12,  13,  14,   0,   0,
                    0,   3,  15,   0,   0,   0,   0,   0,   0,   0,  11,   1,   2,  1,   15,   0,
                    0,   1,  15,   0,   0,   0,   0,   0,   0,   0,   0,  10,   4,  16,   0,   0,
                    0,   3,  15,   0,   0,   0,   0,   0,   0,   0,   0,   0,   9,  0,    0,   0,
                    0,   1,  15,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,  0,    0,   0 },   

        new int[] { 0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,
                    1,   1,   1,   1,   1,   1,   1,   1,   1,   1,   1,   1,   1,   1,   1,   0,
                    9,   9,   9,   9,   9,   9,   9,   9,   9,   9,   9,   9,   1,   1,   1,   0,
                    0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,  10,   1,   1,   0,
                    0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,  11,   1,   0,
                    0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,  11,   1,   0,
                    0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,  11,   1,   0,
                    0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,  11,   1,   0,
                    0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,  11,   1,   0,
                    0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,  11,   1,   0,
                    0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,  11,   1,   0,
                    0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,  11,   1,   0,
                    0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,  11,   1,   0,
                    0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,  11,   1,   0,
                    0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,  11,   1,   0,
                    0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,  11,   1,   0,
                    0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,  11,   1,   0 },     

        new int[] { 0,   1,   15,  0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,
                    0,   1,   14,  0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,
                    0,   1,   1,  14,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,
                    0,   1,   1,  16,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,
                    0,   1,  16,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,
                    0,   3,  15,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,
                    0,   1,  15,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,
                    0,   3,  15,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,
                    0,   1,  15,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,
                    0,   3,  15,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,
                    0,   1,  15,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,
                    0,   3,  15,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,
                    0,   1,  15,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,
                    0,   3,  15,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,
                    0,   1,  15,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,
                    0,   3,  15,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0 },  

        new int[] { 0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,  11,   1,   0,
                    0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,  11,   1,   0,
                    0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,  11,   1,   0,
                    0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,  11,   1,   0,
                    0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,  11,   1,   0,
                    0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,  11,   1,   0,
                    0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,  11,   1,   0,
                    0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,  11,   1,   0,
                    0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,  11,   1,   0,
                    0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,  11,   1,   0,
                    0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,  11,   1,   0,
                    0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,  11,   1,   0,
                    0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,  11,   1,   0,
                    0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,  11,   1,   0,
                    0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,  11,   1,   0,
                    0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,  11,   1,   0,
                    0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,  11,   1,   0 },

        new int[] { 0,   1,  14,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,
                    0,   3,   4,  24,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,
                    0,   1,   2,  18,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,
                    0,   3,   4,  19,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,
                    0,   1,   2,  20,  21,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,
                    0,   3,   4,  22,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,
                    0,   1,   2,  23,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,
                    0,   3,   4,  15,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,
                    0,   1,   2,  14,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,
                    0,   3,   4,   1,  25,  26,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,
                    0,   1,   2,   3,  27,  34,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,
                    0,   3,   4,   1,  28,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,
                    0,   1,   2,   3,  29,  30,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,
                    0,   3,   4,   1,  31,  32,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,
                    0,   1,   2,   3,  33,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,
                    0,   3,   4,   16,  0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0 },  

        new int[] { 0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,  11,   1,   0,
                    0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,  11,   1,   0,
                    0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,  11,   1,   0,
                    0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,  11,   1,   0,
                    0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,  11,   1,   0,
                    0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,  11,   1,   0,
                    0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,  11,   1,   0,
                    0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,  11,   1,   0,
                    0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,  11,   1,   0,
                    0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,  11,   1,   0,
                    0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,  11,   1,   0,
                    0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,  11,   1,   0,
                    0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,  11,   1,   0,
                    0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,  11,   1,   0,
                    0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,  11,   1,   0,
                    0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,  11,   1,   0,
                    0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,  11,   1,   0 },  

        new int[] { 0,   1,  16,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,
                    0,   3,  35,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,
                    0,   1,  36,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,
                    0,   3,  37,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,
                    0,   1,   2,   38,  0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,
                    0,   3,  39,   40,  0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,
                    0,   1,  42,   41, 44,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,
                    0,  45,  46,   50,  0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,
                    0,   1,  47,   48,  0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,
                    0,   3,  4,    3,  14,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,
                    0,   1,  2,    3,   4,  38,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,
                    0,   3,  4,   27,  32,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,
                    0,   1,   2,  35,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,
                    0,   3,   4,   1,  13,  13,  13,  13,  13,  13,  13,  13,  13,  13,  13,  13,
                    0,   1,   2,   1,   2,   1,   2,   1,   2,   1,   2,   1,   2,   1,   2,   1,
                    0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0 },  

        new int[] { 0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,  11,   1,   0,
                    0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,  11,   1,   0,
                    0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,  11,   1,   0,
                    0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,  11,   1,   0,
                    0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,  11,   1,   0,
                    0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,  11,   1,   0,
                    0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,  11,   1,   0,
                    0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,  11,   1,   0,
                    0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,  11,   1,   0,
                    0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,  11,   1,   0,
                    0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,  11,   1,   0,
                    0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,  11,   1,   0,
                    0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,  12,   1,   1,   0,
                   13,  13,  13,  13,  13,  13,  13,  13,  13,  13,  13,  13,   1,   1,   1,   0,
                    1,   1,   1,   1,   1,   1,   1,   1,   1,   1,   1,   1,   1,   1,   1,   0,
                    0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0 }};

        viewport.set_dimensions(2, 4);
        viewport.set_vector(vector);

    return; }

    public void initialize(Core core) {

        this.core = core;

        boundary_manager = core.boundary_manager;
        npc_manager = core.npc_manager;
        parallax = core.parallax;
        viewport = core.viewport;

        get_vector_npcmanager();
        get_vector_parallax();
        get_vector_matrix();

        playable_kuros = new PlayableKuros();
        playable_kuros.initialize(core);

        parallax.set_quotient(0, 3);

        viewport.set_position(100, 300);
        playable_kuros.set_position(200, 400);
        
        viewport.validate_all();

        // temporary

        // background_music = core.Content.Load<Song>("aerith");

        projectile_splash = new ProjectileSplash();
        projectile_splash.initialize(core);

        playable_kuros.projectile_splash = projectile_splash;
        // MediaPlayer.IsRepeating = true;
        // MediaPlayer.Play(background_music);
    return; }

    public void compare_boundary() {

        for (int count = 0; count <= boundary_manager.index; count++) {
            if (boundary_manager.table[count].state == 0)
                return;

        playable_kuros.compare(boundary_manager.table[count]); }

    return; }

    public void process() {

        playable_kuros.process();
        projectile_splash.process();
        npc_manager.process();

        compare_boundary();

        playable_kuros.update();
        npc_manager.update();
        viewport.update();

        playable_kuros.hud();

    return; }

}}