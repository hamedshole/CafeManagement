$.extend(true, $.summernote.lang, {
    'en-US': { /* US English(Default Language) */
            font: {
                bold: "درشت",
                italic: "خمیده",
                underline: 'میان خط',
                clear: 'پاک کردن فرمت فونت',
                height: 'فاصله ی خطی',
                name: 'اسم فونت',
                strikethrough: "Strikethrough",
                subscript: "Subscript",
                superscript: "Superscript",
                size: 'اندازه ی فونت'
            },
            image: {
                image: "تصویر",
                insert: "افزودن تصویر",
                resizeFull: "Resize Full",
                resizeHalf: "Resize Half",
                resizeQuarter: "Resize Quarter",
                floatLeft: "Float Left",
                floatRight: "Float Right",
                floatNone: "Float None",
                shapeRounded: "Shape: Rounded",
                shapeCircle: "Shape: Circle",
                shapeThumbnail: "Shape: Thumbnail",
                shapeNone: "Shape: None",
                dragImageHere: "Drag image or text here",
                dropImage: "Drop image or Text",
                selectFromFiles: "Select from files",
                maximumFileSize: "Maximum file size",
                maximumFileSizeError: "Maximum file size exceeded.",
                url: "Image URL",
                remove: "Remove Image"
            },
            video: {
                video: "ویدیو",
                videoLink: "لینک ویدیو",
                insert: "افزودن ویدیو",
                url: "آدرس ویدیو ؟",
                providers: "(YouTube, Vimeo, Vine, Instagram, DailyMotion or Youku)"
            },
            link: {
                link: "لینک",
                insert: "اضافه کردن لینک",
                unlink: "حذف لینک",
                edit: "ویرایش",
                textToDisplay: "متن جهت نمایش",
                url: "این لینک به چه آدرسی باید برود ؟",
                openInNewWindow: "در یک پنجره ی جدید باز شود"
            },
            table: {table: "جدول"},
            hr: {insert: "خط میانه"},
            style: {
                style: "استایل",
                normal: "نرمال",
                blockquote: "نقل قول",
                pre: "کد",
                h1: 'سرتیتر 1',
                h2: 'سرتیتر 2',
                h3: 'سرتیتر 3',
                h4: 'سرتیتر 4',
                h5: 'سرتیتر 5',
                h6: 'سرتیتر 6'
            },
            lists: {unordered: "لیست غیر ترتیبی", ordered: "لیست ترتیبی"},
            options: {help: "راهنما", fullscreen: "نمایش تمام صفحه", codeview: "مشاهده ی کد"},
            paragraph: {
                paragraph: "پاراگراف",
                outdent: "کاهش تو رفتگی",
                indent: "افزایش تو رفتگی",
                left: "چپ چین",
                center: "میان چین",
                right: "راست چین",
                justify: "بلوک چین"
            },
            color: {
                recent: "رنگ اخیرا استفاده شده",
                more: "رنگ بیشتر",
                background: "رنگ پس زمینه",
                foreground: "رنگ متن",
                transparent: "بی رنگ",
                setTransparent: "تنظیم حالت بی رنگ",
                reset: "بازنشاندن",
                resetToDefault: "حالت پیش فرض"
            },
            shortcut: {
                shortcuts: "دکمه های میان بر",
                close: "بستن",
                textFormatting: "فرمت متن",
                action: "عملیات",
                paragraphFormatting: "فرمت پاراگراف",
                documentStyle: "استیل سند",
                extraKeys: "Extra keys"
            },
            help: {
                insertParagraph: "Insert Paragraph",
                undo: "Undoes the last command",
                redo: "Redoes the last command",
                tab: "Tab",
                untab: "Untab",
                bold: "Set a bold style",
                italic: "Set a italic style",
                underline: "Set a underline style",
                strikethrough: "Set a strikethrough style",
                removeFormat: "Clean a style",
                justifyLeft: "Set left align",
                justifyCenter: "Set center align",
                justifyRight: "Set right align",
                justifyFull: "Set full align",
                insertUnorderedList: "Toggle unordered list",
                insertOrderedList: "Toggle ordered list",
                outdent: "Outdent on current paragraph",
                indent: "Indent on current paragraph",
                formatPara: "Change current block's format as a paragraph(P tag)",
                formatH1: "Change current block's format as H1",
                formatH2: "Change current block's format as H2",
                formatH3: "Change current block's format as H3",
                formatH4: "Change current block's format as H4",
                formatH5: "Change current block's format as H5",
                formatH6: "Change current block's format as H6",
                insertHorizontalRule: "Insert horizontal rule",
                "linkDialog.show": "Show Link Dialog"
            },
    }
});

function toEnglishNumber(strNum,name) {
    var pn = ["۰", "۱", "۲", "۳", "۴", "۵", "۶", "۷", "۸", "۹"];
    var en = ["0", "1", "2", "3", "4", "5", "6", "7", "8", "9"];

    var cache = strNum;
    for (var i = 0; i < 10; i++) {
        var regex_fa = new RegExp(pn[i], 'g');
        cache = cache.replace(regex_fa, en[i]);
    }
    $('#'+name).val(cache);
}





// window.onload = function () {
//     var menus = $('#admin-menu-bar li');
   
//     for (var i = 0; i < menus.length; i++) {
//         if (menus[i].classList.contains('active')) {
//             console.log( menus[i].offsetTop);
//             document.getElementById('admin-menu-bar').scrollTop = menus[i].offsetTop;
//         }
//     }
// }


$(document).ready(function() {
    // پیدا کردن المان li فعال درون المان ul
    var activeLi = $('#admin-menu-bar li.active');
    
    // تنظیم موقعیت اسکرول المان ul به المان li فعال
    $('#admin-menu-bar').scrollTop(activeLi.offset().top - $('#admin-menu-bar').offset().top + $('#admin-menu-bar').scrollTop());
  });


//   $(document).ready(function() {
//     // پیدا کردن المان li فعال درون المان ul
//     var activeLi = $('#admin-menu-bar li.active');
    
//     // جابجایی المان li فعال به ابتدای لیست
//     activeLi.prependTo('#admin-menu-bar');
    
//     // تنظیم موقعیت اسکرول المان ul به المان li فعال
//     $('#admin-menu-bar').scrollTop(activeLi.offset().top - $('#admin-menu-bar').offset().top + $('#admin-menu-bar').scrollTop());
//   });