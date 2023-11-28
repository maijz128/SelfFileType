function Description()
    return
        'JavBus - AV磁力連結分享 - 日本成人影片資料庫';
end

function ExtensionName() return '.javbus'; end

function Icon() return 'javbus.ico'; end

function Urls() return {'javbus.com'}; end

function FileName(url)
    local name = "Jav Bus";
    name = url:gsub("https://www.javbus.com/", "");
	name = name:gsub("https://javbus.com/", "");
    name = name:gsub("/", ".");
    return name;
end


local url = 'https://www.javbus.com/MEYD-559';
print(FileName(url))


