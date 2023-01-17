# Oscilloscope Measurement Logger V01
Tektronix DPO2000用に作りました。
他のテクトロのオシロでも動くかもしれません。

1. オシロとPCをUSB接続しドライバをインストールしてください。  
   ドライバはおそらく自動でインストールされます。

2. Oscillo_Logger.exeを起動し、Measurement SettingゾーンでTime Step（測定間隔）とCycle（何回測定するか）を設定してください。  
   Cycleが空欄の場合は手動で止めるまで測定します。

3. Oscilloscopeゾーンで測定器と接続してください。  
   Connectボタンを押すといくつか表示されると思いますが、  
   他のUSBデバイスをすべて取り外して残ったUSBどうのこうのというリソースがオシロです。

4. Save CSVにログの保存先フォルダとファイル名入力してください。  
   空欄にしておくとログが保存されません。

5. オシロスコープ側のMeasurementを手動で設定してください。  

6. START LOGでMeasurementのログがとれます。  

※
上手く動かなければ同梱のni-visa_20.0_online_repack3.exeをインストールしてください。  
NI-VISAランタイムだけインストールすれば動くと思います。  

maruoka
