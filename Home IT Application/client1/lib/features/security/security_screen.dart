import 'dart:async';

import 'package:flutter/material.dart';
import 'package:home_automation/common/widgets/home_it_button.dart';
import 'package:home_automation/common/widgets/home_it_in_out_field.dart';
import 'package:home_automation/common/widgets/home_it_label.dart';
import 'package:home_automation/common/widgets/home_it_main_screen.dart';
import 'package:home_automation/common/widgets/home_it_switch_button.dart';
import 'package:home_automation/services/security_service.dart';

import '../../common/utils/region_detector/region_detector.dart';
import '../../common/widgets/image_region_detector.dart';

class SecurityScreen extends StatefulWidget {
  const SecurityScreen({Key? key}) : super(key: key);

  @override
  State<SecurityScreen> createState() => _SecurityScreenState();
}

class _SecurityScreenState extends State<SecurityScreen> {
  TextEditingController inOutController1 = TextEditingController();
  TextEditingController inOutController2 = TextEditingController();
  TextEditingController inOutController3 = TextEditingController();
  TextEditingController inOutController4 = TextEditingController();
  SecurityService service = SecurityService();

  late Timer serverCallsTimer;
  bool _isVisible = false;
  bool _isButtonEnable = false;
  bool isOn = false;

  bool validateForm() {
    return true;
  }

  @override
  void initState() {
    inOutController1.text = "00";
    inOutController2.text = "00";
    inOutController3.text = "00";
    inOutController4.text = "00";
    Timer.periodic(const Duration(seconds: 1), (timer) async {
      isOn = await service.getStateAlarm();
      setState(() {});
    });
    super.initState();
  }

  @override
  Widget build(BuildContext context) {
    return HomeItMainScreen(
      title: 'Security',
      widgetImage: ImageRegionDetector(
        imagePath: 'images/security_image.png',
        imageSize: const Size(335, 303),
        regions: RegionDetector.polygonRegions,
        onTap: (index) => Navigator.push(
          context,
          MaterialPageRoute(builder: (_) => RegionDetector.screens[index]),
        ),
      ),
      bottomWidget: Column(
        children: [
          HomeItLabel(
            text: 'Turn on the Alarm',
            secondWidget: HomeItSwitchButton(
              isEnable: !_isVisible,
              value: isOn,
              onChangedTrue: service.turnOnAlarm,
              onChangedFalse: service.turnOffAlarm,
            ),
          ),
          Padding(
            padding: const EdgeInsets.all(20.0),
            child: HomeItButton(
              onPressed: () => setState(() {
                _isVisible = !_isVisible;
                if (_isVisible) {
                  serverCallsTimer =
                      Timer.periodic(const Duration(seconds: 1), (_) async {
                    await service.scheduleAlarm(
                        "${inOutController1.text}:${inOutController2.text}-${inOutController3.text}:${inOutController4.text}");
                  });
                } else {
                  serverCallsTimer.cancel();
                }
              }),
              text: 'Schedule Alarm',
              hasIcon: true,
            ),
          ),
          if (_isVisible)
            Padding(
              padding: const EdgeInsets.only(left: 40, right: 40),
              child: Form(
                onChanged: () => setState(() {
                  _isButtonEnable = validateForm();
                }),
                child: Row(
                  mainAxisAlignment: MainAxisAlignment.spaceEvenly,
                  children: [
                    HomeItInOutField(
                      text: '',
                      controller: inOutController1,
                    ),
                    Text(
                      ':',
                      style: Theme.of(context).textTheme.headlineMedium,
                    ),
                    HomeItInOutField(
                      text: '',
                      controller: inOutController2,
                    ),
                    Text(
                      '-',
                      style: Theme.of(context).textTheme.headlineMedium,
                    ),
                    HomeItInOutField(
                      text: '',
                      controller: inOutController3,
                    ),
                    Text(
                      ':',
                      style: Theme.of(context).textTheme.headlineMedium,
                    ),
                    HomeItInOutField(
                      text: '',
                      controller: inOutController4,
                    )
                  ],
                ),
              ),
            ),
        ],
      ),
    );
  }

  @override
  void dispose() {
    super.dispose();
  }
}
