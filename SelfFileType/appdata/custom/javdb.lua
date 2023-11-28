function Description()
    return
        'JavDB 成人影片資料庫及磁鏈分享';
end

function ExtensionName() return '.javdb'; end

function Icon() return 'javdb.ico'; end

function Urls() return {'javdb.com'}; end

function FileName(url)
    local name = "JavDB";
    name = url:gsub("https://javdb.com/", "");
    name = name:gsub("/", ".");
    return name;
end


-- local url = 'https://javdb.com/v/YwykB';
-- print(FileName(url))


