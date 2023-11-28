function Description()
    return
        '欢迎光临JavLibrary，你的线上日本成人影片情报站。 - JAVLibrary';
end

function ExtensionName() return '.javlibrary'; end

function Icon() return 'javlibrary.ico'; end

function Urls() return {'javlibrary.com'}; end

function FileName(url)
    local name = "JavLibrary";
    -- name = url:gsub("https://javlibrary.com/", "");
	-- name = name:gsub("https://javlibrary.com/", "");
    -- name = name:gsub("/", ".");

    local start = string.find( url, "/?v=");
    if start ~= nil then
        name = string.match(url, "v=(%S+)");
        name = name .. '.video';
    end

    start = string.find( url, "/vl_star.php");
    if start ~= nil then
        name = string.match(url, "s=(%S+)");
        name = name .. '.star';
    end

    start = string.find( url, "/vl_maker.php");
    if start ~= nil then
        name = string.match(url, "m=(%S+)");
        name = name .. '.maker';
    end

    return name;
end


-- local url = 'https://www.javlibrary.com/cn/?v=javmentv7m';
-- local star = 'https://www.javlibrary.com/cn/vl_star.php?s=aydui';
-- local maker = 'https://www.javlibrary.com/cn/vl_maker.php?m=aqsa';
-- print(FileName(url))
-- print(FileName(star))
-- print(FileName(maker))


