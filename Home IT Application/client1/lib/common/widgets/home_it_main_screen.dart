import 'package:flutter/material.dart';
import 'package:home_automation/common/widgets/home_it_app_bar.dart';

import 'home_it_title.dart';

class HomeItMainScreen extends StatefulWidget {
  final String title;
  final Widget widgetImage;
  final bool hasSettings;
  final bool hasBackButton;
  final double paddingBottom;
  final Widget bottomWidget;

  const HomeItMainScreen({
    Key? key,
    required this.title,
    required this.widgetImage,
    required this.bottomWidget,
    this.hasSettings = true,
    this.hasBackButton = true,
    this.paddingBottom = 100.0,
  }) : super(key: key);

  @override
  State<HomeItMainScreen> createState() => _HomeItMainScreenState();
}

class _HomeItMainScreenState extends State<HomeItMainScreen> {
  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: HomeItAppBar(
        hasSettings: widget.hasSettings,
        hasBackButton: widget.hasBackButton,
      ),
      body: LayoutBuilder(builder: (context, constraints) {
        return Container(
          decoration: const BoxDecoration(
            image: DecorationImage(
              image: AssetImage('images/home_it_background.png'),
              fit: BoxFit.fill,
            ),
          ),
          child: SingleChildScrollView(
            child: ConstrainedBox(
              constraints: BoxConstraints(
                minHeight: constraints.maxHeight,
              ),
              child: Column(
                mainAxisAlignment: MainAxisAlignment.spaceBetween,
                children: [
                  HomeItTitle(text: widget.title),
                  widget.widgetImage,
                  Padding(
                    padding: EdgeInsets.only(bottom: widget.paddingBottom),
                    child: widget.bottomWidget,
                  ),
                ],
              ),
            ),
          ),
        );
      }),
    );
  }
}
