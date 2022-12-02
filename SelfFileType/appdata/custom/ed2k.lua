function Description()
    return
        'eD2k链接（eD2k links (ed2k://) ）是一种超链接，用于指示在eDonkey网络上存储的文件。';
end

function ExtensionName() return '.ed2k'; end

function Icon() return 'ed2k.ico'; end

function Urls() return {'ed2k://'}; end

function FileName(url)
    local name = "ed2k";
    local fname, fsize, hash
    local start = string.find( url, "ed2k://|file|");
    if start ~= nil then
        fname, fsize, hash = string.match(url, "^ed2k://|file|(.+)|([A-Fa-f0-9]+)|([A-Fa-f0-9]+)")
        -- name = string.match(url, "ed2k://|file|(.+)")
        name = fname .. '.' .. fsize;
        -- name = fname;
    end
    return name;
end




local url = 'ed2k://|file|[枪火.the.mission.1999.dvdrip.x264.ac3-ken.mkv|2205863836|0C25BD3A18E22398775697A168E0FE95|]枪火';
print(FileName(url))

