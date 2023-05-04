import 'package:flutter/material.dart';
import 'package:home_automation/common/app_constants.dart';

class HomeItSwitchButton extends StatefulWidget {
  final String trueText;
  final String falseText;
  final VoidCallback? onChangedTrue;
  final VoidCallback? onChangedFalse;
  final bool value;
  final bool isEnable;

  const HomeItSwitchButton({
    Key? key,
    this.trueText = "",
    this.falseText = "",
    this.onChangedTrue,
    this.onChangedFalse,
    this.value = false,
    this.isEnable = true,
  }) : super(key: key);

  @override
  State<HomeItSwitchButton> createState() => _HomeItSwitchButtonState();
}

class _HomeItSwitchButtonState extends State<HomeItSwitchButton> {
  late bool semaphore;

  @override
  Widget build(BuildContext context) {
    semaphore = widget.value;
    return SizedBox(
      width: 120,
      child: Column(
        children: [
          Switch(
            // thumb color (round icon)
            activeColor: AppConstants.yellow,
            activeTrackColor: Colors.black,
            inactiveThumbColor: AppConstants.yellow,
            inactiveTrackColor: Colors.grey.shade400,
            splashRadius: 50.0,
            // boolean variable value
            value: semaphore,
            // changes the state of the switch
            onChanged: widget.isEnable
                ? (value) => setState(() {
                      semaphore = value;
                      if (semaphore == true) {
                        widget.onChangedTrue!.call();
                      } else {
                        widget.onChangedFalse!.call();
                      }
                    })
                : null,
          ),
          semaphore
              ? Text(widget.trueText,
                  style:
                      const TextStyle(fontSize: 15, color: AppConstants.green))
              : Text(widget.falseText,
                  style:
                      const TextStyle(fontSize: 15, color: AppConstants.red)),
        ],
      ),
    );
  }
}
