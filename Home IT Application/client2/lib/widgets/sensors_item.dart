import 'package:client2/widgets/sensors_slider.dart';
import 'package:flutter/material.dart';

class SensorsItem extends StatefulWidget {
  final String text;
  final Widget widget;

  const SensorsItem({Key? key, required this.text, required this.widget}) : super(key: key);

  @override
  State<SensorsItem> createState() => _SensorsItemState();
}

class _SensorsItemState extends State<SensorsItem> {
  @override
  Widget build(BuildContext context) {
    return Padding(
      padding: const EdgeInsets.all(9.0),
      child: Row(
        mainAxisAlignment: MainAxisAlignment.spaceBetween,
        children: [
          Text(
            widget.text,
            style: Theme.of(context).textTheme.titleLarge,
          ),
          widget.widget
        ],
      ),
    );
  }
}
