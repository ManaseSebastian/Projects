import 'package:flutter/material.dart';

import '../../../features/doors/doors_screen.dart';
import '../../../features/garage/garage_screen.dart';
import '../../../features/light/light_screen.dart';
import '../../../features/security/security_screen.dart';
import '../../../features/temperature/temperature_screen.dart';

class RegionDetector{
  static const List<List<Offset>> points = [
    [
      Offset(37, 44),
      Offset(44, 65),
      Offset(62, 72),
      Offset(82, 64),
      Offset(70, 20),
      Offset(48, 25),
    ],
    [
      Offset(91, 73),
      Offset(109, 89),
      Offset(135, 82),
      Offset(142, 60),
      Offset(128, 42),
      Offset(103, 43),
    ],
    [
      Offset(166, 74),
      Offset(191, 65),
      Offset(195, 43),
      Offset(181, 25),
      Offset(155, 26),
      Offset(154, 44),
    ],
    [
      Offset(213, 86),
      Offset(232, 88),
      Offset(246, 75),
      Offset(246, 51),
      Offset(226, 38),
      Offset(205, 46),
      Offset(198, 63),
    ],
    [
      Offset(264, 69),
      Offset(288, 69),
      Offset(300, 54),
      Offset(296, 29),
      Offset(271, 21),
      Offset(252, 40),
    ],
  ];

  static final List<Path> polygonRegions = points.map((e) {
    Path p = Path();
    p.addPolygon(e, true);
    return p;
  }).toList();

  static final List<Widget> screens = [
    const TemperatureScreen(),
    const LightScreen(),
    const DoorsScreen(),
    const GarageScreen(),
    const SecurityScreen()
  ];
}