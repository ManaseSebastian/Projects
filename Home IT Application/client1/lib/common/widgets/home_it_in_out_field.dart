import 'package:flutter/material.dart';

import '../app_constants.dart';

class HomeItInOutField extends StatefulWidget {
  final String text;
  final bool isOut;
  final TextEditingController? controller;

  const HomeItInOutField({
    Key? key,
    required this.text,
    this.isOut = false,
    this.controller,
  }) : super(key: key);

  @override
  State<HomeItInOutField> createState() => _HomeItInOutFieldState();
}

class _HomeItInOutFieldState extends State<HomeItInOutField> {
  @override
  Widget build(BuildContext context) {
    return SizedBox(
      width: 50,
      height: 40,
      child: Container(
        decoration: const BoxDecoration(color: AppConstants.black),
        child: TextFormField(
          controller: widget.controller,
          style: Theme.of(context).textTheme.labelMedium?.copyWith(
              color: widget.isOut
                  ? AppConstants.black.withOpacity(0.7)
                  : AppConstants.black),
          decoration: InputDecoration(
            hintText: widget.text,
            hintStyle: Theme.of(context).textTheme.labelMedium?.copyWith(
                color: widget.isOut
                    ? AppConstants.black.withOpacity(0.7)
                    : AppConstants.black),
            filled: true,
            fillColor: AppConstants.yellow,
            contentPadding: const EdgeInsets.only(left: 17, bottom: 6),
          ),
          readOnly: widget.isOut ? true : false,
        ),
      ),
    );
  }
}
