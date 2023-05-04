import 'dart:async';

import 'package:flutter/material.dart';
import 'package:home_automation/common/widgets/home_it_button.dart';
import 'package:home_automation/common/widgets/home_it_in_out_field.dart';
import 'package:home_automation/common/widgets/home_it_label.dart';
import 'package:home_automation/common/widgets/home_it_main_screen.dart';
import 'package:home_automation/common/widgets/home_it_switch_button.dart';
import 'package:home_automation/common/widgets/image_region_detector.dart';

import '../../common/app_constants.dart';
import '../../common/utils/region_detector/region_detector.dart';
import '../../services/doors_service.dart';

class DoorsScreen extends StatefulWidget {
  const DoorsScreen({Key? key}) : super(key: key);

  @override
  State<DoorsScreen> createState() => _DoorsScreenState();
}

class _DoorsScreenState extends State<DoorsScreen> {
  TextEditingController inOutController1 = TextEditingController();
  TextEditingController inOutController2 = TextEditingController();

  TextEditingController inOutPINController1 = TextEditingController();
  TextEditingController inOutPINController2 = TextEditingController();
  TextEditingController inOutPINController3 = TextEditingController();
  TextEditingController inOutPINController4 = TextEditingController();

  DoorsService service = DoorsService();
  bool _isAutomaticVisible = false;
  bool _isPINVisible = true;
  bool isLocked = false;
  late Timer serverCallsTimer;

  @override
  void initState() {
    inOutController1.text = "00";
    inOutController2.text = "00";
    inOutPINController1.text = "0";
    inOutPINController2.text = "0";
    inOutPINController3.text = "0";
    inOutPINController4.text = "0";
    Timer.periodic(const Duration(seconds: 1), (timer) async {
      isLocked = await service.getStateDoors();
      setState(() {});
    });
    super.initState();
  }

  @override
  Widget build(BuildContext context) {
    return HomeItMainScreen(
      title: 'Doors',
      widgetImage: ImageRegionDetector(
        imagePath: 'images/doors_image.png',
        imageSize: const Size(335, 303),
        regions: RegionDetector.polygonRegions,
        onTap: (index) => Navigator.push(
          context,
          MaterialPageRoute(builder: (_) => RegionDetector.screens[index]),
        ),
      ),
      paddingBottom: 80,
      bottomWidget: Column(
        children: [
          HomeItLabel(
            text: 'Lock the door',
            secondWidget: HomeItSwitchButton(
              isEnable: !isLocked,
              value: isLocked,
              onChangedTrue: service.lockDoors,
             // onChangedFalse: service.unlockDoors,
            ),
          ),
          Padding(
            padding: const EdgeInsets.symmetric(horizontal: 20),
            child: HomeItButton(
              onPressed: _isPINVisible
                  ? () => setState(() {
                        _isAutomaticVisible = !_isAutomaticVisible;
                        _isPINVisible = !_isPINVisible;
                        if (_isAutomaticVisible) {
                          serverCallsTimer = Timer.periodic(
                              const Duration(seconds: 1), (_) async {
                            await service.scheduleLock(
                                "${inOutController1.text}:${inOutController2.text}");
                          });
                        } else {
                          serverCallsTimer.cancel();
                        }
                      })
                  : null,
              text: 'Automatic lock',
              hasIcon: true,
            ),
          ),
          if (_isAutomaticVisible)
            HomeItLabel(
              text: 'Set time',
              secondWidget: Row(
                children: [
                  HomeItInOutField(controller: inOutController1, text: ''),
                  Text(
                    ':',
                    style: Theme.of(context).textTheme.headlineMedium,
                  ),
                  HomeItInOutField(controller: inOutController2, text: ''),
                ],
              ),
            ),
          Padding(
            padding: const EdgeInsets.all(20),
            child: HomeItButton(
              text: 'PIN for the key',
              onPressed: _isAutomaticVisible
                  ? () => setState(() {
                        serverCallsTimer.cancel();
                        _isPINVisible = !_isPINVisible;
                        _isAutomaticVisible = !_isAutomaticVisible;
                      })
                  : null,
              hasIcon: true,
            ),
          ),
          if (_isPINVisible)
            Padding(
              padding: const EdgeInsets.only(right: 70, left: 70),
              child: Row(
                mainAxisAlignment: MainAxisAlignment.spaceEvenly,
                children: [
                  HomeItInOutField(
                    text: '',
                    controller: inOutPINController1,
                  ),
                  HomeItInOutField(
                    text: '',
                    controller: inOutPINController2,
                  ),
                  HomeItInOutField(
                    text: '',
                    controller: inOutPINController3,
                  ),
                  HomeItInOutField(
                    text: '',
                    controller: inOutPINController4,
                  )
                ],
              ),
            ),
          if (_isPINVisible)
            Padding(
              padding: const EdgeInsets.only(top: 20),
              child: ElevatedButton(
                onPressed: () => setState(() async {
                  await service.verifyPINLock(
                      "${inOutPINController1.text}${inOutPINController2.text}${inOutPINController3.text}${inOutPINController4.text}");
                }),
                style: ElevatedButton.styleFrom(
                  backgroundColor: AppConstants.black,
                  foregroundColor: Colors.white,
                  elevation: 20, // Elevation
                  shadowColor: Colors.black, // Background color
                ),
                child: const Text('Unlock Door'),
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
