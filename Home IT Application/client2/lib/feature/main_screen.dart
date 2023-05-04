import 'package:client2/constants/app_constants.dart';
import 'package:client2/service/temperature_service.dart';
import 'package:client2/widgets/in_out_field.dart';
import 'package:client2/widgets/sensors_item.dart';
import 'package:flutter/material.dart';

import '../service/doors_service.dart';
import '../widgets/sensors_slider.dart';

class MainScreen extends StatefulWidget {
  const MainScreen({Key? key}) : super(key: key);

  @override
  State<MainScreen> createState() => _MainScreenState();
}

class _MainScreenState extends State<MainScreen> {
  TextEditingController inOutPINController1 = TextEditingController();
  TextEditingController inOutPINController2 = TextEditingController();
  TextEditingController inOutPINController3 = TextEditingController();
  TextEditingController inOutPINController4 = TextEditingController();

  TemperatureService temperatureService = TemperatureService();
  DoorsService service = DoorsService();
  GlobalKey<SensorsSliderState> temperatureSliderKey = GlobalKey();
  late SensorsSlider temperatureSlider;

  @override
  void initState() {
    inOutPINController1.text = "0";
    inOutPINController2.text = "0";
    inOutPINController3.text = "0";
    inOutPINController4.text = "0";

    temperatureSlider = SensorsSlider(
      key: temperatureSliderKey,
      service: temperatureService,
      divisions: 200,
    );
    super.initState();
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: const Text(AppConstants.appTitle),
        centerTitle: true,
        backgroundColor: AppConstants.black,
      ),
      body: LayoutBuilder(builder: (context, constraints) {
        return Container(
          decoration: const BoxDecoration(
            image: DecorationImage(
              image: AssetImage('images/background.png'),
              fit: BoxFit.fill,
            ),
          ),
          child: SingleChildScrollView(
            child: ConstrainedBox(
              constraints: BoxConstraints(
                minHeight: constraints.maxHeight,
              ),
              child: Column(
                children: [
                  SensorsItem(
                      text: AppConstants.featuresTexts[0],
                      widget: temperatureSlider),
                  SensorsItem(
                      text: AppConstants.featuresTexts[1],
                      widget: SensorsSlider(
                        service: temperatureService,
                      )),
                  SensorsItem(
                      text: AppConstants.featuresTexts[2],
                      widget: SensorsSlider(
                        service: temperatureService,
                      )),
                  SensorsItem(
                    text: AppConstants.featuresTexts[3],
                    widget: Column(
                      children: [
                        Row(
                          children: [
                            InOutField(
                              text: '',
                              controller: inOutPINController1,
                              maxLength: 1,
                            ),
                            InOutField(
                              text: '',
                              controller: inOutPINController2,
                              maxLength: 1,
                            ),
                            InOutField(
                              text: '',
                              controller: inOutPINController3,
                            ),
                            InOutField(
                              text: '',
                              controller: inOutPINController4,
                            ),
                          ],
                        ),
                        Padding(
                          padding: const EdgeInsets.only(top: 10),
                          child: ElevatedButton(
                            onPressed: () => setState(() async {
                              if (inOutPINController1.text.isNotEmpty &&
                                  inOutPINController2.text.isNotEmpty &&
                                  inOutPINController3.text.isNotEmpty &&
                                  inOutPINController4.text.isNotEmpty) {
                                await service.setPINLock(
                                    "${inOutPINController1.text}${inOutPINController2.text}${inOutPINController3.text}${inOutPINController4.text}");
                              }
                            }),
                            style: ElevatedButton.styleFrom(
                              backgroundColor: AppConstants.black,
                              foregroundColor: Colors.white,
                              elevation: 20, // Elevation
                              shadowColor: Colors.black, // Background color
                            ),
                            child: const Text('Set PIN for lock'),
                          ),
                        ),
                      ],
                    ),
                  ),
                ],
              ),
            ),
          ),
        );
      }),
    );
  }
}
