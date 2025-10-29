<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm3.aspx.cs" Inherits="HotalManagment.WebForm3" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="js/calendar/fullcalendar.min.css" rel="stylesheet" type="text/css" />
    <script src="js/calendar/moment.min.js" type="text/javascript"></script>
    <script src="js/calendar/jquery.min.js" type="text/javascript"></script>
    <script src="js/calendar/fullcalendar.min.js" type="text/javascript"></script>
<script type="text/javascript">
var events ;
function GetEvents() {
            $.ajax({
        type: "POST",
        url: "WebForm3.aspx/GetEvents",
        async: false,
        data: '{}',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function(response) {
            //alert("success:"+JSON.stringify(response.d));
            events = response.d;
        },
        failure: function(response) {
            alert("error:"+response.d);
        }
    });
        }

  $(document).ready(function() {
  GetEvents();
  //alert(events.length);
  //alert("msg:"+events);
//  $.each(events,function(key,value){
//    alert(key +" : "+value.title);
//  });
    $('#calendar').fullCalendar({
      header: {
        left: 'prev,next today',
        center: 'title',
        right: 'month,agendaWeek,agendaDay,listWeek'
      },
      defaultDate: $.now(),//'2018-02-12',
      navLinks: true, // can click day/week names to navigate views
      editable: false,
      eventLimit: true, // allow "more" link when too many events
      events: events
//      events: [
//        {
//          title: 'All Day Event',
//          start: '2018-02-01',
//        },
//        {
//          title: 'Long Event',
//          start: '2018-02-07',
//          end: '2018-02-10'
//        },
//        {
//          id: 999,
//          title: 'Repeating Event',
//          start: '2018-02-09T16:00:00'
//        },
//        {
//          id: 999,
//          title: 'Repeating Event',
//          start: '2018-02-16T16:00:00'
//        },
//        {
//          title: 'Conference',
//          start: '2018-02-11',
//          end: '2018-02-13'
//        },
//        {
//          title: 'Meeting',
//          start: '2018-02-12T10:30:00',
//          end: '2018-02-12T12:30:00'
//        },
//        {
//          title: 'Lunch',
//          start: '2018-02-12T12:00:00'
//        },
//        {
//          title: 'Meeting',
//          start: '2018-02-12T14:30:00'
//        },
//        {
//          title: 'Happy Hour',
//          start: '2018-02-12T17:30:00'
//        },
//        {
//          title: 'Dinner',
//          start: '2018-02-12T20:00:00'
//        },
//        {
//          title: 'Birthday Party',
//          start: '2018-02-13T07:00:00'
//        },
//        {
//          title: 'Click for Google',
//          url: 'http://google.com/',
//          start: '2018-02-28'
//        }
//      ]
    });

  });

</script>
    <style>
        body
        {
            margin: 40px 10px;
            padding: 0;
            font-family: "Lucida Grande" ,Helvetica,Arial,Verdana,sans-serif;
            font-size: 14px;
        }
        #calendar
        {
            max-width: 900px;
            margin: 0 auto;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div id='calendar'>
    </div>
    </form>
</body>
</html>
