import 'dart:developer';

import 'package:flutter/material.dart';

import '../service/temperature_service.dart';

class SensorsSlider extends StatefulWidget {
  final int divisions;
  final Service service;

  const SensorsSlider({
    Key? key,
    required this.service,
    this.divisions = 100,
  }) : super(key: key);

  @override
  State<SensorsSlider> createState() => SensorsSliderState();
}

class SensorsSliderState extends State<SensorsSlider> {
  double _currentSliderValue = 20;

  double get currentSliderValue => _currentSliderValue;

  @override
  Widget build(BuildContext context) {
    return Slider(
      value: _currentSliderValue,
      max: 100,
      divisions: widget.divisions,
      label: _currentSliderValue.toStringAsFixed(1),
      onChanged: (double value) {
        setState(() {
          _currentSliderValue = value;
          if (widget.service is TemperatureService) {
            (widget.service as TemperatureService).setCurrentTemperature(_currentSliderValue.toStringAsFixed(1));
          }
        });
      },
    );
  }
}
