import 'package:flutter/material.dart';

import '../app_constants.dart';

class HomeItLabel extends StatefulWidget {
  final String text;
  final Widget secondWidget;

  const HomeItLabel({Key? key, required this.text, required this.secondWidget})
      : super(key: key);

  @override
  State<HomeItLabel> createState() => _HomeItLabelState();
}

class _HomeItLabelState extends State<HomeItLabel> {
  @override
  Widget build(BuildContext context) {
    return Padding(
      padding: const EdgeInsets.only(top: 20),
      child: Row(
        children: [
          Expanded(
            child: SizedBox(
              height: 40,
              child: Padding(
                padding: const EdgeInsets.only(left: 20),
                child: Container(
                  decoration: const BoxDecoration(color: AppConstants.yellow),
                  child: Center(
                    child: Text(
                      widget.text,
                      style: Theme.of(context)
                          .textTheme
                          .titleMedium
                          ?.copyWith(color: AppConstants.black),
                    ),
                  ),
                ),
              ),
            ),
          ),
          Padding(
            padding: const EdgeInsets.only(left: 20, right: 20),
            child: widget.secondWidget,
          ),
        ],
      ),
    );
  }
}
