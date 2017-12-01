import { Component } from '@angular/core';
import { NavController } from 'ionic-angular';
import * as HighCharts from 'highcharts';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs/Rx'

@Component({
    selector: 'page-live',
    templateUrl: 'live.html'
})
export class LivePage {

axisData: any;
chart: any;

constructor(public navCtrl: NavController, private _http: HttpClient) {
}

ionViewDidLoad()
{
    HighCharts.setOptions({
        global: {
            useUTC: false
        }
    });

    this.axisData = [];
    this.axisData.push([(new Date()).getTime(), 10]);
    this.axisData.push([(new Date()).getTime(), 20]);

    this.chart = HighCharts.chart('container', {
    chart: {
        type: 'spline',
        animation: HighCharts.svg, // don't animate in old IE
        marginRight: 10,
        events: {
            load: function () {
                // // set up the updating of the chart each second
                // var series = this.series[0];
                // setInterval(function () {
                //     var x = (new Date()).getTime(), // current time
                //         y = Math.floor(0 + (15000 + 1 - 0) * (Math.pow(Math.random(),3)));
                //     series.addPoint([x, y], true, true);
                // }, 1000);
            }
        }
    },
    title: {
        text: 'Treating Pressure'
    },
    xAxis: {
        min: (new Date()).getTime(),
        type: 'datetime',
        tickPixelInterval: 150
        //tickInterval: 100
    },
    yAxis: {
        max: 15000,
        min: 0,
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
        name: 'Treating Pressure',
        data: this.axisData
        
    }]
});

    this.RefreshData();
}

    RefreshData() {
        let headers = new HttpHeaders();
        headers = headers.append('Content-Type', 'application/json');
        // headers.append('Authorization', 'Basic' + btoa('hacker' + ":" + 'Pa$$w0rd'));
        headers = headers.append('Authorization', 'Basic aGFja2VyOlBhJCR3MHJk');
        
        var x = (new Date(2017, 10, 1, 19, 35, 0)); // current time
        console.log(x);
        console.log(x.getTime());
        var that = this;
        var series = this.chart.series[0];

        setInterval(function() {
            //var stringDate = x.toLocaleTimeString("");
            var options = { day: '2-digit', month: 'short', year: 'numeric', hour: '2-digit', minute: '2-digit', second: '2-digit' };
            console.log(x.toLocaleDateString("en-US",options));
            that._http.get('https://pi.dvnhackathon.com/piwebapi/streamsets/E0kmIZsN6_90OPP6Ztf91JxQQG-r8JTT5xGpRgANOmHTrQT1NJU09GVFBJLTAwMVxERVZPTlxTS0lEU1xTS0lEICM3Nw/value?time=' + x.toLocaleDateString("en-US",options) + '&selectedFields=Items.Name;Items.Value.Value', { headers: headers })
                //.map(data => data.toString().
                .subscribe(data => {
                    console.log(data);
                    console.log(x);
                    var items = data.Items;
                    console.log(items);
                    var treatPress = that.FilterItems("Treating Pressure", items);
                    var slurryRate = that.FilterItems("Slurry Rate", items);
                    var tp = treatPress.Value.Value;
                    var sr = slurryRate.Value.Value;
                    
                    // that.axisData.push([(new Date()).getTime(),tp]);
                    // that.chart.redraw();
                    series.addPoint([(new Date()).getTime(), tp], true, false);
                    console.log(series.points);

                    //var jsonData = JSON.parse(data.toString());
                    //resolve(data);
                }, err => {
                    console.log(err);
                });
            
            var ms = x.getTime() + 1440000;
            x = new Date(ms);
        }, 2000);
    }

    FilterItems(name: string, items) : any {
        for(var i = 0; i < items.length; i++) {
            if(items[i].Name === name) {
                return items[i];
            }
        }
        return null;
    }

}
