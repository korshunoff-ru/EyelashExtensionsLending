var date = {
    currentDate: undefined,
    calendarDate: undefined
};

var daysOffset = 0;

$( document ).ready(function() {
   initializeCalendar();
   //    $.ajax({
   //      url: "http://localhost:5000/api/date",
   //      type: "GET",
   //      contentType: "application/json",
   //      dataType: 'json',
   //      success: function(result){
   //          date.currentDate = new Date(result);
   //          date.calendarDate = new Date(result);

   //          $("#yearCalendar").text(date.calendarDate.getFullYear());
   //          $("#monthCalendar").text(getMonthName(date.calendarDate.getMonth()));

   //          var counter = 0;
   //          $("#panelDayCalendar li").each(function(index, value) {
   //              if (index >= 1 && index <= 5 ) {
   //                  var tempDate = new Date(date.calendarDate);
   //                  tempDate.setDate(date.calendarDate.getDate() + counter);
   //                  $(this).find('span').eq(0).text(tempDate.getDate());
   //                  $(this).find('span').eq(1).text(getDayName(tempDate.getDay()));
   //                  counter++;
   //              }
   //          });

   //          $(`.calendar-full .days span:contains("${date.currentDate.getDate()}")`).addClass('active');

   //      }
   //  });

 });

 function dayNext() {
    var counter = 0;
    $("#panelDayCalendar li").each(function(index, value) {
        if (index >= 1 && index <= 5 ) {
            var tempDate = new Date(date.calendarDate);
            tempDate.setDate(date.calendarDate.getDate() + counter);
            $(this).find('span').eq(0).text(tempDate.getDate());
            $(this).find('span').eq(1).text(getDayName(tempDate.getDay()));
            counter++;
        }
    });
    date.calendarDate.setDate(date.calendarDate.getDate() + 1);

    $("#yearCalendar").text(date.calendarDate.getFullYear());
    $("#monthCalendar").text(getMonthName(date.calendarDate.getMonth()));
 }

 function dayPrev() {
    var counter = -1;
    $("#panelDayCalendar li").each(function(index, value) {
        if (index >= 1 && index <= 5 ) {
            var tempDate = new Date(date.calendarDate);
            tempDate.setDate(date.calendarDate.getDate() + counter);
            $(this).find('span').eq(0).text(tempDate.getDate());
            $(this).find('span').eq(1).text(getDayName(tempDate.getDay()));
            counter++;
        }
    });
    date.calendarDate.setDate(date.calendarDate.getDate() - 1)

    $("#yearCalendar").text(date.calendarDate.getFullYear());
    $("#monthCalendar").text(getMonthName(date.calendarDate.getMonth()));

 }

 $('#btn-calendar-show').click(function() {
    $('.calendar .content').slideToggle( { // отображаем, или скрываем элементы <div> в документе
      duration: 500, // продолжительность анимации
      easing: "swing",
      queue: false,
      start: function() {
         if ($('.calendar .content').is(':visible')) {
            $('.mini-calendar').css('border-radius', '10px 10px 0px 0px');
         }
      },
      done: function() {
         if (!$('.calendar .content').is(':visible')) {
            $('.mini-calendar').css('border-radius', '10px');
         } else {
            $('.mini-calendar').css('border-radius', '10px 10px 0px 0px');
         }
      }
    });
 })

 function getMonthNameByNumber(number) {
     switch (number) {
         case 0:
            return "ЯНВАРЬ";
         case 1:
            return "ФЕВРАЛЬ";
         case 2:
            return "МАРТ";
         case 3:
            return "АПРЕЛЬ";
         case 4:
            return "МАЙ";
         case 5:
            return "ИЮНЬ";
         case 6:
            return "ИЮЛЬ";
         case 7:
            return "АВГУСТ";
         case 8:
            return "СЕНТЯБРЬ";
         case 9:
            return "ОКТЯБРЬ";
         case 10:
            return "НОЯБРЬ";
         case 11:
            return "ДЕКАБРЬ";
         default:
             return "МЕСЯЦ";
     }
 }

function getDayNameByNumber(number) {
    switch (number) {
        case 0:
           return "ВС";
        case 1:
           return "ПН";
        case 2:
           return "ВТ";
        case 3:
           return "СР";
        case 4:
           return "ЧТ";
        case 5:
           return "ПТ";
        case 6:
           return "СБ";
        default:
            return "??";
    }
}

var calendar = {};
function initializeCalendar() {
   calendar.initialize();
   var currentDate = new Date();

}

var calendar = {
   cursor: new Date(),
   getCurrentTime: function() {
      return new Date(); 
   },

   initialize: function() {
      this.cursor.setDate(1);
      for(var i = 0; i < 5; i++) {
         var tempDate = new Date();
         tempDate.setDate(this.cursor.getDate() + i);
         $('.mini-calendar-item .day-link .day').eq(i).text(tempDate.getDate());
         $('.mini-calendar-item .day-link .week').eq(i).text(getDayNameByNumber(tempDate.getDay()));
      }
   
      $('#month').text(getMonthNameByNumber(this.cursor.getMonth()));
      $('#year').text(this.cursor.getFullYear());
      this.updateDaysMonth();
   },

   prevMonth: function() {
      this.cursor.setMonth(this.cursor.getMonth() - 1);
      $('#month').text(getMonthNameByNumber(this.cursor.getMonth()));
      $('#year').text(this.cursor.getFullYear());

      this.updateDaysMonth();
   },

   nextMonth: function() {
      this.cursor.setMonth(this.cursor.getMonth() + 1);
      this.cursor.setDate(1);
      $('#month').text(getMonthNameByNumber(this.cursor.getMonth()));
      $('#year').text(this.cursor.getFullYear());
      
      this.updateDaysMonth();

   },

   updateDaysMonth: function() {
      var tempDate = new Date(this.cursor.toUTCString());
      for (var i = 0; i < 5; i++) {

         if (tempDate.getDay() == 0) {
            tempDate.setDate(tempDate.getDate() - 6);
         } else {
            tempDate.setDate(tempDate.getDate() - (tempDate.getDay() - 1));
         }
         for (var j = 0; j < 7; j++) {
            $(`.days .week:eq(${i}) .day .day-link`).eq(j).removeClass('gray');
            var date = new Date(tempDate);
            date.setDate(tempDate.getDate() + j);
            $(`.days .week:eq(${i}) .day .day-link`).eq(j).text(date.getDate());

            if (date.getMonth() != this.cursor.getMonth()) {
               $(`.days .week:eq(${i}) .day .day-link`).eq(j).addClass('gray');
            }

         }
         tempDate.setDate(tempDate.getDate() + 7);
      }
   }

}

$('#next-month').click(function() {
   calendar.nextMonth()
})

$('#prev-month').click(function() {
   calendar.prevMonth()
})