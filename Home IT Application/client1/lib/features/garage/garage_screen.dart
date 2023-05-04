import 'package:flutter/material.dart';
import 'package:home_automation/common/widgets/home_it_in_out_field.dart';
import 'package:home_automation/common/widgets/home_it_label.dart';
import 'package:home_automation/common/widgets/home_it_main_screen.dart';
import 'package:home_automation/common/widgets/home_it_switch_button.dart';

import '../../common/utils/region_detector/region_detector.dart';
import '../../common/widgets/image_region_detector.dart';

class GarageScreen extends StatefulWidget {
  const GarageScreen({Key? key}) : super(key: key);

  @override
  State<GarageScreen> createState() => _GarageScreenState();
}

class _GarageScreenState extends State<GarageScreen> {
  @override
  Widget build(BuildContext context) {
    return HomeItMainScreen(
      title: 'Garage',
      widgetImage: ImageRegionDetector(
        imagePath: 'images/garage_image.png',
        imageSize: const Size(335, 303),
        regions: RegionDetector.polygonRegions,
        onTap: (index) => Navigator.push(
          context,
          MaterialPageRoute(builder: (_) => RegionDetector.screens[index]),
        ),
      ),
      bottomWidget: Column(
        children: const [
          HomeItLabel(
              text: 'Lock the door', secondWidget: HomeItSwitchButton()),
          HomeItLabel(
            text: 'Proximity sensor',
            secondWidget: HomeItInOutField(text: '2m'),
          ),
          HomeItLabel(text: 'Timer for lock', secondWidget: HomeItInOutField(text: '20s'))
        ],
      ),
    );
  }
}
