# Oscilloscope Measurement Logger V01

## Function
- Saves a log of values on oscilloscope's "Measure" function.
- The transition is displayed on the graph.
- Made for Tektronix DPO2000. (Other Tektro oscilloscopes may also work.)

## How to use
1. Connect the oscilloscope and PC via USB and install the driver.
    The driver will probably install automatically.

2. Start Oscillo_Logger.exe and set the Time Step (measurement interval) and Cycle (how many times to measure) in the Measurement Setting zone.
    If Cycle is blank, measurements will continue until manually stopped.

3. Connect your instrument in the Oscilloscope zone.
    If you press the Connect button, some will appear, but the resource left after removing all other USB devices is the oscilloscope.

4. Enter the log save destination folder and file name in Save CSV.
    If left blank, the log will not be saved.

5. Manually set the measurement settings on the oscilloscope.

6. START LOG will log the measurement.

※
If it doesn't work, please install the included "ni-visa_20.0_online_repack3.exe".
Just install the NI-VISA runtime and it should work.

maru
