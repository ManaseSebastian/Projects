import 'package:flutter/material.dart';
import 'package:home_automation/common/utils/region_detector/region_detector.dart';
import '../../common/widgets/home_it_main_screen.dart';
import '../../common/widgets/image_region_detector.dart';

class HomeScreen extends StatefulWidget {
  const HomeScreen({Key? key}) : super(key: key);

  @override
  State<HomeScreen> createState() => _HomeScreenState();
}

class _HomeScreenState extends State<HomeScreen> {
  @override
  Widget build(BuildContext context) {
    return HomeItMainScreen(
      hasBackButton: false,
      title: 'Welcome to your dream house!',
      widgetImage: Image.asset('images/home_text.png'),
      bottomWidget: ImageRegionDetector(
        imagePath: 'images/home_image.png',
        imageSize: const Size(335, 303),
        regions: RegionDetector.polygonRegions,
        onTap: (index) => Navigator.push(
          context,
          MaterialPageRoute(builder: (_) => RegionDetector.screens[index]),
        ),
      ),
    );
  }
}
