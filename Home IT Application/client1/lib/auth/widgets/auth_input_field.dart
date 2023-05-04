import 'package:flutter/material.dart';

class AuthInputField extends StatefulWidget {
  final TextEditingController? controller;
  final String hintText;
  final bool isObscure;
  final Image image;
  final FormFieldValidator<String>? validator;

  const AuthInputField({
    Key? key,
    this.controller,
    required this.hintText,
    required this.image,
    this.isObscure = false,
    this.validator,
  }) : super(key: key);

  @override
  State<AuthInputField> createState() => _AuthInputFieldState();
}

class _AuthInputFieldState extends State<AuthInputField> {
  @override
  Widget build(BuildContext context) {
    return Row(
      crossAxisAlignment: CrossAxisAlignment.start,
      children: [
        widget.image,
        Expanded(
          child: Padding(
            padding: const EdgeInsets.only(left: 12),
            child: TextFormField(
              validator: widget.validator,
              autovalidateMode: AutovalidateMode.onUserInteraction,
              controller: widget.controller,
              style: Theme.of(context)
                  .textTheme
                  .subtitle2
                  ?.copyWith(color: Colors.white),
              obscureText: widget.isObscure,
              decoration: InputDecoration(
                hintText: widget.hintText,
                hintStyle: Theme.of(context)
                    .textTheme
                    .subtitle2
                    ?.copyWith(color: Colors.white),
                filled: true,
                fillColor: Colors.black.withOpacity(0.65),
                contentPadding: const EdgeInsets.only(left: 10),
              ),
            ),
          ),
        ),
      ],
    );
  }
}
