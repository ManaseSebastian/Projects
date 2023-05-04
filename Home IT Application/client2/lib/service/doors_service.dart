import 'package:http/http.dart';

import '../constants/app_constants.dart';

class DoorsService{
  final String setPINLockURL =
      "http://${AppConstants.address}/api/doors/setPINLock";

  Future<void> setPINLock(String lock) async {
    Response res = await post(
      Uri.parse(setPINLockURL),
      body: lock,
    );

    if (res.statusCode == 200) {
    } else {
      throw "Unable to retrieve data.";
    }
  }
}