Function WeightedAverage ([int[]]$numbs)
{
    $x = @()
    $y = @()
    $cnt = 1
    foreach ($n in $numbs)
    {
        if ($cnt%2 -eq 1)
        {
            $x += $n
            $a = $n
        }
        else
        {
            $b = $n
            $y += ($a*$b)
        }
        $cnt++
    }
 
    $y = ($y | Measure-Object -Sum).Sum
    $x = ($x | Measure-Object -Sum).Sum
    $result = ($y / $x)
    return $result
}
 
WeightedAverage -numbs 20,90,25,95,30,85



Function GetMedian ([int[]]$numbs)
{
    $numbs = $numbs | Sort-Object
    if ($numbs.Count % 2 -eq 1)
    {
        $medianpos = [Math]::Floor($numbs.Count/2)
        return $numbs[$medianpos]
    }
    else
    {
        $x = $numbs[$numbs.Count/2]
        $y = $numbs[(($numbs.Count/2)-1)]
        return ($x,$y | Measure-Object -Average).Average
    }
}

GetMedian 5,7,9,11,2,5
