import { Component } from '@angular/core';
import { NavController } from 'ionic-angular';
import * as HighCharts from 'highcharts';

@Component({
selector: 'page-live',
templateUrl: 'live.html'
})
export class LivePage {

constructor(public navCtrl: NavController) {
}

ionViewDidLoad(){
    HighCharts.setOptions({
    global: {
        useUTC: false
    }
});

HighCharts.chart('container', {
    chart: {
        type: 'spline',
        animation: HighCharts.svg, // don't animate in old IE
        marginRight: 10,
        events: {
            load: function () {

                // set up the updating of the chart each second
                var series = this.series[0];
                setInterval(function () {
                    var x = (new Date()).getTime(), // current time
                        y = Math.floor(0 + (15000 + 1 - 0) * (Math.pow(Math.random(),3)));
                    series.addPoint([x, y], true, true);
                }, 1000);
            }
        }
    },
    title: {
        text: 'Treating Pressure'
    },
    xAxis: {
        type: 'datetime',
        tickPixelInterval: 150
    },
    yAxis: {
        title: {
            text: 'Value'
        },
        plotLines: [{
            value: 0,
            width: 1,
            color: '#808080'
        }]
    },
    tooltip: {
        formatter: function () {
            return '<b>' + this.series.name + '</b><br/>' +
                HighCharts.dateFormat('%Y-%m-%d %H:%M:%S', this.x) + '<br/>' +
                HighCharts.numberFormat(this.y, 2);
        }
    },
    legend: {
        enabled: false
    },
    exporting: {
        enabled: false
    },
    series: [{
        name: 'Random data',
        data: (function () {
            // generate an array of random data
            var data = [],
                time = (new Date()).getTime(),
                i;

            for (i = -19; i <= 0; i += 1) {
                data.push({
                    x: time + i * 1000,
                    y: Math.floor(0 + (15000 + 1 - 0) * (Math.pow(Math.random(),3)))
                });
            }
            return data;
        }())
    }]
});
}

}