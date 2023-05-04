import 'package:flutter/material.dart';

class HomeItSlider extends StatefulWidget {
  const HomeItSlider({Key? key}) : super(key: key);

  @override
  State<HomeItSlider> createState() => _HomeItSliderState();
}

class _HomeItSliderState extends State<HomeItSlider> {
  double _currentSliderValue = 20;

  double get currentSliderValue => _currentSliderValue;

  @override
  Widget build(BuildContext context) {
    return Slider(
      value: _currentSliderValue,
      max: 100,
      divisions: 5,
      label: _currentSliderValue.round().toString(),
      onChanged: (double value) {
        setState(() {
          _currentSliderValue = value;
        });
      },
    );
  }
}
