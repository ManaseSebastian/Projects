import 'package:flutter/material.dart';
import 'package:home_automation/common/widgets/home_it_button.dart';
import 'package:home_automation/common/widgets/home_it_in_out_field.dart';
import 'package:home_automation/common/widgets/home_it_label.dart';
import 'package:home_automation/common/widgets/home_it_main_screen.dart';
import 'package:home_automation/common/widgets/home_it_slider.dart';

import '../../common/utils/region_detector/region_detector.dart';
import '../../common/widgets/image_region_detector.dart';

class LightScreen extends StatefulWidget {
  const LightScreen({Key? key}) : super(key: key);

  @override
  State<LightScreen> createState() => _LightScreenState();
}

class _LightScreenState extends State<LightScreen> {
  HomeItSlider homeItSlider =  HomeItSlider();
  bool _isVisibleManually = true;
  bool _isVisibleAutomated = false;

  double _currentValue = 20;
  TextEditingController sliderController = TextEditingController();

  void handleManuallyButton() {}

  @override
  Widget build(BuildContext context) {
    return HomeItMainScreen(
      title: 'Light',
      widgetImage: ImageRegionDetector(
        imagePath: 'images/light_image.png',
        imageSize: const Size(335, 303),
        regions: RegionDetector.polygonRegions,
        onTap: (index) => Navigator.push(
          context,
          MaterialPageRoute(builder: (_) => RegionDetector.screens[index]),
        ),
      ),
      paddingBottom: 35,
      bottomWidget: Column(
        children: [
          Padding(
            padding: const EdgeInsets.only(top: 10, bottom: 10),
            child: Text(
              'Set the light intensity in the house',
              style: Theme.of(context).textTheme.titleLarge,
            ),
          ),
          ColorFiltered(
            colorFilter: ColorFilter.mode(
                Colors.amber.withOpacity(0.01 * _currentValue), BlendMode.color),
            child: Padding(
              padding: const EdgeInsets.all(8.0),
              child: Image.asset('images/light_bulb.png'),
            ),
          ),
          Padding(
            padding: const EdgeInsets.all(8.0),
            child: HomeItButton(
                onPressed: _isVisibleAutomated
                    ? () => setState(() {
                          _isVisibleManually = !_isVisibleManually;
                          _isVisibleAutomated = !_isVisibleAutomated;
                        })
                    : null,
                text: 'Manually',
                hasIcon: true),
          ),
          if (_isVisibleManually)
             HomeItLabel(
              text: 'Light intensity',
              secondWidget: Slider(
                value: _currentValue,
                max: 100,
                divisions: 5,
                label: _currentValue.round().toString(),
                onChanged: (double value) {
                  setState(() {
                    _currentValue = value;
                  });
                },
              ),
            ),
          Padding(
            padding: const EdgeInsets.all(8.0),
            child: HomeItButton(
                onPressed: _isVisibleManually
                    ? () => setState(() {
                          _isVisibleAutomated = !_isVisibleAutomated;
                          _isVisibleManually = !_isVisibleManually;
                        })
                    : null,
                text: 'Automated',
                hasIcon: true),
          ),
          if (_isVisibleAutomated)
          const HomeItLabel(
            text: 'Set light intensity',
            secondWidget: HomeItInOutField(text: '20'),
          ),
        ],
      ),
    );
  }
}
