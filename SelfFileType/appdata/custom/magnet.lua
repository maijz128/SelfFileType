function Description()
    return
        '磁力链接，P2P文件共享。';
end

function ExtensionName() return '.magnet'; end

function Icon() return 'magnet.ico'; end

function Urls() return {'magnet:?'}; end

function FileName(url)
    local name = "magnet";
    local fname, fsize, hash
    local start = string.find( url, "magnet:?");
    if start ~= nil then
        fname = string.match(url, "dn=(.-)&")
        name = fname;
    end
    return name;
end




local url = 'magnet:?xt=urn:btih:4D9FA761D69964B00DF0B3B0C9C1F968EA6C47D0&xt=urn:ed2k:7655dbacff9395e579c4c9cb49cbec0e&dn=bbb_sunflower_2160p_30fps_stereo_abl.mp4&tr=udp%3a%2f%2ftracker.openbittorrent.com%3a80%2fannounce&tr=udp%3a%2f%2ftracker.publicbt.com%3a80%2fannounce&ws=http%3a%2f%2fdistribution.bbb3d.renderfarming.net%2fvideo%2fmp4%2fbbb_sunflower_2160p_30fps_stereo_abl.mp4';
print(FileName(url))

