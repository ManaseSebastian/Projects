import 'package:flutter/material.dart';

class ImageRegionDetector extends StatefulWidget {
  final String imagePath;
  final List<Path> regions;
  final void Function(int) onTap;
  final Size imageSize;

  const ImageRegionDetector({
    Key? key,
    required this.imagePath,
    required this.imageSize,
    required this.onTap,
    required this.regions,
  }) : super(key: key);

  @override
  State<ImageRegionDetector> createState() => _ImageRegionDetectorState();
}

class _ImageRegionDetectorState extends State<ImageRegionDetector> {
  @override
  Widget build(BuildContext context) {
    return GestureDetector(
      onTapDown: (details) {
        RenderBox b = context.findRenderObject() as RenderBox;
        Offset locPos = details.localPosition;
        double widthMul = widget.imageSize.width / b.size.width;
        double heightMul = widget.imageSize.height / b.size.height;
        Offset rawPos = Offset(locPos.dx * widthMul, locPos.dy * heightMul);
        for (int i = 0; i < widget.regions.length; i++) {
          if (widget.regions[i].contains(rawPos)) {
            widget.onTap(i);
            return;
          }
        }
      },
      child: Image.asset(widget.imagePath),
    );
  }
}
