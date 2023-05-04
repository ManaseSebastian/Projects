import 'package:flutter/material.dart';
import 'package:home_automation/common/app_constants.dart';

class HomeItTitle extends StatelessWidget {
  final String text;

  const HomeItTitle({
    Key? key,
    required this.text,
  }) : super(key: key);

  @override
  Widget build(BuildContext context) {
    return SizedBox(
      width: double.infinity,
      height: 60,
      child: Container(
        decoration: const BoxDecoration(color: AppConstants.yellow),
        child: Center(
          child: Padding(
            padding: const EdgeInsets.all(16.0),
            child: Text(
              text,
              style: Theme.of(context).textTheme.headlineSmall?.copyWith(shadows: [
              const Shadow(color: Colors.black, offset: Offset(-1.0, -1.0)),
              ]),
            ),
          ),
        ),
      ),
    );
  }
}
