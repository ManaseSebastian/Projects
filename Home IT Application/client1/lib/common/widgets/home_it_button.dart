import 'package:flutter/material.dart';
import 'package:home_automation/common/app_constants.dart';

class HomeItButton extends StatelessWidget {
  final String text;
  final bool hasIcon;
  final bool changeColor;
  final VoidCallback? onPressed;

  const HomeItButton({
    Key? key,
    required this.onPressed,
    required this.text,
    this.hasIcon = false,
    this.changeColor = false,
  }) : super(key: key);

  @override
  Widget build(BuildContext context) {
    return SizedBox(
      width: double.infinity,
      height: 42,
      child: ElevatedButton(
        onPressed: onPressed,
        style: ButtonStyle(
          backgroundColor: MaterialStateProperty.resolveWith(
            (states) {
              if (states.contains(MaterialState.disabled)) {
                return AppConstants.black.withOpacity(0.6);
              }
              return !changeColor
                  ? AppConstants.black
                  : AppConstants.black.withOpacity(0.2);
            },
          ),
          side: MaterialStateBorderSide.resolveWith(
            (states) => const BorderSide(
              width: 1.0,
              color: AppConstants.black,
            ),
          ),
          shape: MaterialStateProperty.all(
            RoundedRectangleBorder(
              borderRadius: BorderRadius.circular(15),
            ),
          ),
        ),
        child: hasIcon
            ? Padding(
                padding: const EdgeInsets.all(9),
                child: Row(
                  mainAxisAlignment: MainAxisAlignment.spaceBetween,
                  children: [
                    Text(
                      text,
                      style: Theme.of(context)
                          .textTheme
                          .titleLarge
                          ?.copyWith(color: Colors.white),
                    ),
                    const Icon(
                      Icons.chevron_right,
                      color: Colors.white,
                      size: 30,
                    ),
                  ],
                ),
              )
            : Text(
                text,
                style: Theme.of(context)
                    .textTheme
                    .titleLarge
                    ?.copyWith(color: Colors.white),
              ),
      ),
    );
  }
}
