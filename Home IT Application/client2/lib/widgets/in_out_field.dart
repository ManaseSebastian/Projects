import 'package:flutter/material.dart';

import '../constants/app_constants.dart';

class InOutField extends StatefulWidget {
  final String text;
  final bool isOut;
  final TextEditingController? controller;
  final int maxLength;

  const InOutField({
    Key? key,
    required this.text,
    this.isOut = false,
    this.controller,
    this.maxLength = 2,
  }) : super(key: key);

  @override
  State<InOutField> createState() => _InOutFieldState();
}

class _InOutFieldState extends State<InOutField> {
  @override
  Widget build(BuildContext context) {
    return Padding(
      padding: const EdgeInsets.all(1),
      child: SizedBox(
        width: 50,
        height: 40,
        child: Container(
          decoration: const BoxDecoration(color: AppConstants.black),
          child: TextFormField(
            maxLength: widget.maxLength,
            controller: widget.controller,
            style: Theme.of(context).textTheme.labelMedium?.copyWith(
                color: widget.isOut
                    ? AppConstants.white.withOpacity(0.7)
                    : AppConstants.white),
            decoration: InputDecoration(
              hintText: widget.text,
              hintStyle: Theme.of(context).textTheme.labelMedium?.copyWith(
                  color: widget.isOut
                      ? AppConstants.white.withOpacity(0.7)
                      : AppConstants.white),
              filled: true,
              fillColor: AppConstants.black,
              contentPadding: const EdgeInsets.only(left: 17, bottom: 6),
            ),
            readOnly: widget.isOut ? true : false,
          ),
        ),
      ),
    );
  }
}
