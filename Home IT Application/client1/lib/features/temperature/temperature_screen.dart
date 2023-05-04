import 'dart:async';

import 'package:flutter/material.dart';
import 'package:home_automation/common/widgets/home_it_label.dart';
import 'package:home_automation/common/widgets/home_it_switch_button.dart';
import 'package:home_automation/services/temperature_service.dart';

import '../../common/utils/region_detector/region_detector.dart';
import '../../common/widgets/home_it_in_out_field.dart';
import '../../common/widgets/home_it_main_screen.dart';
import '../../common/widgets/image_region_detector.dart';

class TemperatureScreen extends StatefulWidget {
  const TemperatureScreen({Key? key}) : super(key: key);

  @override
  State<TemperatureScreen> createState() => _TemperatureScreenState();
}

class _TemperatureScreenState extends State<TemperatureScreen> {
  TemperatureService service = TemperatureService();
  TextEditingController desiredTemperature = TextEditingController();
  bool isPowerPlantWorking = false;
  late Timer serverCallsTimer;
  late double currentTemperature = 0;

  @override
  void initState() {
    Future.delayed(
      const Duration(seconds: 0),
      () async =>
          desiredTemperature.text = "${await service.getDesiredTemperature()}",
    );
    serverCallsTimer = Timer.periodic(const Duration(seconds: 1), (_) async {
      currentTemperature = await service.getCurrentTemperature();
      isPowerPlantWorking = await service.isPowerPlantWorking();
      setState(() {});
    });
    super.initState();
  }

  @override
  Widget build(BuildContext context) {
    return GestureDetector(
      onTap: () async {
        FocusManager.instance.primaryFocus?.unfocus();
        if (desiredTemperature.text.isEmpty) {
          desiredTemperature.text = "0.0";
        }
        await service.setDesiredTemperature(desiredTemperature.text);
      },
      child: HomeItMainScreen(
        title: 'Temperature',
        widgetImage: ImageRegionDetector(
          imagePath: 'images/temperature_image.png',
          imageSize: const Size(335, 303),
          regions: RegionDetector.polygonRegions,
          onTap: (index) => Navigator.push(
            context,
            MaterialPageRoute(builder: (_) => RegionDetector.screens[index]),
          ),
        ),
        bottomWidget: Column(
          children: [
            Padding(
              padding: const EdgeInsets.only(top: 10),
              child: Text(
                'Set the temperature in the house',
                style: Theme.of(context).textTheme.titleLarge,
              ),
            ),
            HomeItLabel(
              text: 'Current Temperature',
              secondWidget: HomeItInOutField(
                text: currentTemperature.toStringAsFixed(1),
                isOut: true,
              ),
            ),
            HomeItLabel(
              text: 'Desired Temperature',
              secondWidget: HomeItInOutField(
                text: '',
                controller: desiredTemperature,
              ),
            ),
            HomeItLabel(
              text: 'Power Plant',
              secondWidget: HomeItSwitchButton(
                trueText: 'The power plant is now running.',
                falseText: 'The power plant is turned off.',
                onChangedTrue: service.startPowerPlant,
                onChangedFalse: service.stopPowerPlant,
                value: isPowerPlantWorking,
              ),
            ),
          ],
        ),
      ),
    );
  }

  @override
  void dispose() {
    serverCallsTimer.cancel();
    super.dispose();
  }
}
