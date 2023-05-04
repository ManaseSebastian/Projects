import 'dart:convert';

import 'package:http/http.dart';

import '../common/app_constants.dart';

class TemperatureService {
  final String getCurrentTemperatureURL =
      "http://${AppConstants.address}/api/temperature/getCurrentTemperature";
  final String getDesiredTemperatureURL =
      "http://${AppConstants.address}/api/temperature/getDesiredTemperature";
  final String setDesiredTemperatureURL =
      "http://${AppConstants.address}/api/temperature/setDesiredTemperature";
  final String startPowerPlantURL =
      "http://${AppConstants.address}/api/temperature/startPowerPlant";
  final String stopPowerPlantURL =
      "http://${AppConstants.address}/api/temperature/stopPowerPlant";
  final String isPowerPlantWorkingURL =
      "http://${AppConstants.address}/api/temperature/isPowerPlantWorking";

  Future<double> getCurrentTemperature() async {
    Response res = await get(Uri.parse(getCurrentTemperatureURL));

    if (res.statusCode == 200) {
      final response = jsonDecode(res.body);
      return response;
    } else {
      throw "Unable to retrieve stock data.";
    }
  }

  Future<double> getDesiredTemperature() async {
    Response res = await get(Uri.parse(getDesiredTemperatureURL));

    if (res.statusCode == 200) {
      final response = jsonDecode(res.body);
      return response;
    } else {
      throw "Unable to retrieve stock data.";
    }
  }

  Future<void> setDesiredTemperature(String desiredTemperature) async {
    Response res = await post(
      Uri.parse(setDesiredTemperatureURL),
      body: desiredTemperature,
    );

    if (res.statusCode == 200) {
    } else {
      throw "Unable to retrieve stock data.";
    }
  }

  Future<void> startPowerPlant() async {
    Response response = await get(Uri.parse(startPowerPlantURL));

    if (response.statusCode == 200) {
    } else {
      throw "Unable to retrieve stock data.";
    }
  }

  Future<void> stopPowerPlant() async {
    Response response = await get(Uri.parse(stopPowerPlantURL));

    if (response.statusCode == 200) {
    } else {
      throw "Unable to retrieve stock data.";
    }
  }

  Future<bool> isPowerPlantWorking() async {
    Response res = await get(Uri.parse(isPowerPlantWorkingURL));

    if (res.statusCode == 200) {
      final response = jsonDecode(res.body);
      return response;
    } else {
      throw "Unable to retrieve stock data.";
    }
  }
}
